using BookingService.Application.Interfaces;
using BookingService.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IBookingValidatorService, BookingValidatorService>();
            return services;
        }
    }
}
