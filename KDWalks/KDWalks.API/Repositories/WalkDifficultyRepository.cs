using KDWalks.API.Data;
using KDWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace KDWalks.API.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly KDWalksDbContext dbContext;

        public WalkDifficultyRepository(KDWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();
            await dbContext.WalkDifficulty.AddAsync(walkDifficulty);
            await dbContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public  async Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            var existingWalkDifficulty = await dbContext.WalkDifficulty.FindAsync(id);
            if (existingWalkDifficulty == null)
            {
                return null;
            }
            dbContext.WalkDifficulty.Remove(existingWalkDifficulty);
            await dbContext.SaveChangesAsync();
            return existingWalkDifficulty;

        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await dbContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty?> GetAsync(Guid id)
        {
            return await dbContext.WalkDifficulty
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        // ✅ FIXED METHOD SIGNATURE
        public async Task<WalkDifficulty?> UpdateAsync(WalkDifficulty walkDifficulty)
        {
            var existingWalkDifficulty =
                await dbContext.WalkDifficulty.FindAsync(walkDifficulty.Id);

            if (existingWalkDifficulty == null)
            {
                return null;
            }

            existingWalkDifficulty.Code = walkDifficulty.Code;
            await dbContext.SaveChangesAsync();

            return existingWalkDifficulty;
        }
    }
}
