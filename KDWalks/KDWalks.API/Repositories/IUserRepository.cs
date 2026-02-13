using KDWalks.API.Models.Domain;

namespace KDWalks.API.Repositories
{
    public interface IUserRepository
    {
        Task<User?> AuthenticateAsync(string username, string password);
    }
}
