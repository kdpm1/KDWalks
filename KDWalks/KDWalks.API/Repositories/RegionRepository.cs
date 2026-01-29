using KDWalks.API.Data;
using KDWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace KDWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly KDWalksDbContext dbContext;

        public RegionRepository(KDWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }
    }
}
