using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IDifficultyRepositoy
    {
        Task<List<Difficulty>> GetAllAsync();
    }
}
