using AuthService.Domain.Interfaces.Repositories;
using StackExchange.Redis;

namespace AuthService.Infrastructure.Repositories
{
    public class RefreshTokenRepositories : IRefreshTokenRepositories
    {
        private readonly IDatabase _redisDB;
        private const string Key_Prefix = "refresh_token";
        public RefreshTokenRepositories(IConnectionMultiplexer redisDB)
        {
            _redisDB = redisDB.GetDatabase();
        }
        public async Task<(string, TimeSpan)> GetUserIdFromTokenAsync(string token)
        {
            var key = GetKey(token);
            string? userId = await _redisDB.StringGetAsync(key);
            TimeSpan? ttl = await _redisDB.KeyTimeToLiveAsync(key);

            return (userId, ttl ?? TimeSpan.Zero);
        }

        public async Task RemoveTokenAsync(string oldRefreshToken)
        {
            var key = GetKey(oldRefreshToken);
            await _redisDB.KeyDeleteAsync(key);
        }

        public async Task StoreTokenAsync(string userId, string token, TimeSpan expiry)
        {
            var key = GetKey(token);
            await _redisDB.StringSetAsync(key, userId, expiry, When.Always, CommandFlags.PreferReplica);
        }

        public async Task<bool> TokenExistsAsync(string userId, string token)
        {
            var storedToken = await GetUserIdFromTokenAsync(userId);
            return storedToken.Item1 == token;
        }

        private string GetKey(string userId)
        {
            return $"{Key_Prefix}:{userId}";
        }
    }
}
