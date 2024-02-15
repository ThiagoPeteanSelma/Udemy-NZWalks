using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    // Demonstration value in memory...
    // in program.cs change builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
    // to builder.Services.AddScoped<IRegionRepository, InMemoryRegionRepository>();
    public class InMemoryRegionRepository : IRegionRepository
    {
        public Task<Region> CreateAsync(Region region)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return new List<Region> 
            {

                new Region()
                {
                    Id = Guid.NewGuid(),
                    Code = "THI",
                    Name = "Thiago's Region Name"
                }
            };
        
        }

        public Task<Region?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> UpdateAsync(Guid id, Region region)
        {
            throw new NotImplementedException();
        }
    }
}
