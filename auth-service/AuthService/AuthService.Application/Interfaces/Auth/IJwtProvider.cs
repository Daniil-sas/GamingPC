using AuthService.Application.DTOs.JwtToken;
using AuthService.Domain.Models;

namespace AuthService.Application.Interfaces.Auth
{
    public interface IJwtProvider
    {
        AccessToken GenerateToken(User user);

        RefreshToken GenerateRefreshToken();
    }
}
