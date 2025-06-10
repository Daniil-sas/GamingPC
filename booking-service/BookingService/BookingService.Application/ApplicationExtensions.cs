using BookingService.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplciation(this IServiceCollection services)
        {
            services.AddScoped<BookingPlaceService>();
            services.AddScoped<BookingsService>();
            services.AddScoped<HallService>();
            services.AddScoped<SeatService>();

            return services;
        }
    }
}
