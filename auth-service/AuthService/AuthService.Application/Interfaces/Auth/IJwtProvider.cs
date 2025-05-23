using AuthService.Domain.Models;

namespace AuthService.Application.Interfaces.Auth
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
