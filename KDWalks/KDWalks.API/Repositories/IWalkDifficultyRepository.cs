namespace KDWalks.API.Repositories
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<Models.Domain.WalkDifficulty>> GetAllAsync();
       Task<Models.Domain.WalkDifficulty> GetAsync(Guid id);
       Task<Models.Domain.WalkDifficulty> AddAsync(Models.Domain.WalkDifficulty walkDifficulty);
       Task<Models.Domain.WalkDifficulty> UpdateAsync(Models.Domain.WalkDifficulty walkDifficulty);
        Task<Models.Domain.WalkDifficulty> DeleteAsync(Guid id);

    }
}
