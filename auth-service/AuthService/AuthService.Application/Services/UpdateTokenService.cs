using AuthService.Application.DTOs;
using AuthService.Application.Interfaces.Auth;
using AuthService.Domain.Interfaces.Repositories;

namespace AuthService.Application.Services
{
    public class UpdateTokenService
    {
        private readonly IRefreshTokenRepositories _refreshTokenRepositories;
        private readonly IJwtProvider _jwtProvider;
        private readonly IUserRepository _userRepository;
        public UpdateTokenService(IRefreshTokenRepositories refreshTokenRepositories, IJwtProvider jwtProvider, IUserRepository userRepository)
        {
            _refreshTokenRepositories = refreshTokenRepositories;
            _jwtProvider = jwtProvider;
            _userRepository = userRepository;
        }

        public async Task<JWTTokenResult?> UpdateTokens(string refreshToken)
        {
            var (storedUserId, hisTTL) = await _refreshTokenRepositories.GetUserIdFromTokenAsync(refreshToken);

            if (storedUserId == null || hisTTL <= TimeSpan.Zero)
            {
                return null;
            }

            await _refreshTokenRepositories.RemoveTokenAsync(refreshToken);

            var newRefreshToken = _jwtProvider.GenerateRefreshToken();

            await _refreshTokenRepositories.StoreTokenAsync(storedUserId, newRefreshToken.Token, newRefreshToken.ExpiriesIn);

            var user = await _userRepository.GetById(storedUserId);
            var newAccessToken = _jwtProvider.GenerateToken(user);

            return new(newAccessToken.Token, newRefreshToken.Token);
        }
    }
}
