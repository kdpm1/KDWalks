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

        // CREATE
        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        // READ - all
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        // READ - by id
        public async Task<Region?> GetAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        // DELETE
        public async Task<Region?> DeleteAsync(Guid id)
        {
            var region = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (region == null)
            {
                return null;
            }

            dbContext.Regions.Remove(region);
            await dbContext.SaveChangesAsync();

            return region;
        }


        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await dbContext.Regions
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;

            await dbContext.SaveChangesAsync();
            return existingRegion;
        }

    }
}
