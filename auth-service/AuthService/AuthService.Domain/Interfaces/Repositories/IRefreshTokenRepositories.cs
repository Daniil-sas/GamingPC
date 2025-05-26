namespace AuthService.Domain.Interfaces.Repositories
{
    public interface IRefreshTokenRepositories
    {
        Task<(string, TimeSpan)> GetUserIdFromTokenAsync(string userId);
        Task StoreTokenAsync(string userId, string token, TimeSpan expiry);
        Task RemoveTokenAsync(string oldRefreshToken);
        Task<bool> TokenExistsAsync(string userId, string token);
    }
}
