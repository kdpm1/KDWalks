using KDWalks.API.Data;
using KDWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace KDWalks.API.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly KDWalksDbContext dbContext;

        public WalkRepository(KDWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();

            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();

            return walk; // ✅ MUST return
        }

        public async Task<Walk> DeleteAsync(Guid id)
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

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await dbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .ToListAsync();
        }

        public async Task<Walk?> GetAsync(Guid id)
        {
            return await dbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Walk walk)
        {
            var existingWalk = await dbContext.Walks.FindAsync(walk.Id);

            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Length = walk.Length;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.WalkDifficultyId = walk.WalkDifficultyId;

            await dbContext.SaveChangesAsync();
            return existingWalk;
        }

    }
}
