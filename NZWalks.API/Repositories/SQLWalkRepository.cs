using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using StructureMap.Pipeline;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLWalkRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await dbContext.Walks.FindAsync(id);
            if (existingWalk == null)
            {
                return null;
            }

            dbContext.Walks.Remove(existingWalk);

            await dbContext.SaveChangesAsync();

            return existingWalk;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, 
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            var walks = dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

            // Filtering
    
            if(!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery)) 
            {
                walks = filterOn.ToString().ToLower() switch
                {
                    "name" => walks.Where(x => x.Name == filterQuery),
                    "description" => walks.Where(x => x.Description == filterQuery),
                    _ => throw new ArgumentException("Filter not implemented"),
                };
            }

            // Sorting
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                walks = sortBy.ToString().ToLower() switch
                {
                    "name" => isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name),
                    "description" => isAscending ? walks.OrderBy(x => x.Description) : walks.OrderByDescending(x => x.Description),
                    "length" => isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm),
                    _ => throw new ArgumentException("Sort not implemented"),
                };
            }

            // Pagination

            var skipresults = (pageNumber - 1) * pageSize;


            return await walks.Skip(skipresults).Take(pageSize).ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks.FindAsync(id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await dbContext.Walks.FindAsync(id);
            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            //existingWalk.WalkImageUrl = walk.WalkImageUrl;

            await dbContext.SaveChangesAsync();

            return existingWalk;
        }
    }
}
