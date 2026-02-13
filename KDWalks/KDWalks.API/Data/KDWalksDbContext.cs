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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Role>()
                .HasOne(x => x.Role)
                .WithMany(y => y.UsersRoles)
                .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<User_Role>()
               .HasOne(x => x.User)
               .WithMany(y => y.UsersRoles)
               .HasForeignKey(x => x.UserId);
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet <Role> Roles { get; set; }

        public DbSet <User_Role> User_Roles { get; set; }




        // Example DbSet (replace or add more later)
        // public DbSet<Region> Regions { get; set; }
        // public DbSet<Walk> Walks { get; set; }
    }
}
