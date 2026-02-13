using KDWalks.API.Data;
using KDWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace KDWalks.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KDWalksDbContext dbContext;

        public UserRepository(KDWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            var user = await dbContext.Users
                .FirstOrDefaultAsync(x =>
                    x.Username == username &&
                    x.Password == password);

            return user;
        }
    }
}
