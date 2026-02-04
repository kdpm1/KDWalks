using KDWalks.API.Models.Domain;    
namespace KDWalks.API.Repositories
{
    public interface IWalkRepository
    {
      Task<IEnumerable<Walk>> GetAllAsync();
      Task<Walk> GetAsync(Guid id);
      Task<Walk> AddAsync(Walk walk);
       Task<Walk> UpdateAsync(Walk walk);
        Task<Walk> DeleteAsync(Guid id);
    }
}
