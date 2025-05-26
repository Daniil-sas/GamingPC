using AuthService.Application.Interfaces.Auth;
using AuthService.Domain.Interfaces.Repositories;
using AuthService.Infrastructure.Repositories;
using AuthService.Infrastructure.Services;
using AuthService.Infrastructure.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace AuthService.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IRefreshTokenRepositories, RefreshTokenRepositories>();
            services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var setting = sp.GetService<IOptions<RedisSetting>>().Value;
                return ConnectionMultiplexer.Connect(setting.ConnectionString);
            });

            return services;
        }
    }
}
