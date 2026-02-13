using KDWalks.API.Models.Domain;

namespace KDWalks.API.Repositories
{
    public class StaticUserRepository : IUserRepository
    {
        private readonly List<User> users = new List<User>
        {
            new User
            {
                Id = Guid.NewGuid(),
                Username = "admin",
                Password = "admin123",
                Role = "Admin",
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@gmail.com"
            }
        };

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            var user = users.FirstOrDefault(x =>
                x.Username == username &&
                x.Password == password);

            return await Task.FromResult(user);
        }
    }
}
