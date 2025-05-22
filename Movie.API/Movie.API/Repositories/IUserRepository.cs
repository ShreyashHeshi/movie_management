using Movie.API.Models;

namespace Movie.API.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task CreateUserAsync(User user);
    }
}
