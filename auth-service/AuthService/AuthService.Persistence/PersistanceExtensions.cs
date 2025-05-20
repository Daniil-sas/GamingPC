using AuthService.Domain.Interfaces.Repositories;
using AuthService.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Persistence
{
    public static class PersistanceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var t = configuration.GetConnectionString(nameof(AuthServiceDbContext));
            services.AddDbContext<AuthServiceDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(AuthServiceDbContext)));
            });

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
