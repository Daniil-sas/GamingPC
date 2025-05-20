using AuthService.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<UserService>();

            return services;
        }
    }
}
