using KDWalks.API.Models.Domain;

namespace KDWalks.API.Repositories
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User user);
    }
}