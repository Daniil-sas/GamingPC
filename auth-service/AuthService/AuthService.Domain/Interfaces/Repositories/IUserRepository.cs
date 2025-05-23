using AuthService.Domain.Models;

namespace AuthService.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task<User> GetByEmail(string email);
    }
}
