using KDWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace KDWalks.API.Data
{
    public class KDWalksDbContext : DbContext
    {
        public KDWalksDbContext(DbContextOptions<KDWalksDbContext> options)
            : base(options)
        {
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }


        // Example DbSet (replace or add more later)
        // public DbSet<Region> Regions { get; set; }
        // public DbSet<Walk> Walks { get; set; }
    }
}
