using AuthService.Domain.Interfaces.Repositories;
using AuthService.Persistence.Repositories;
using AuthService.Persistence.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AuthService.Persistence
{
    public static class PersistanceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<AuthServiceDbContext>((dbService, options) =>
            {
                var setting = dbService.GetRequiredService<IOptions<DatabaseSettings>>().Value;

                options.UseNpgsql(setting.ConnectionString);
            });

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
