using KDWalks.API.Models.Domain;

namespace KDWalks.API.Repositories
{
    public interface IRegionRepository
    {
       Task <IEnumerable<Region>> GetAllAsync();
    }
}
