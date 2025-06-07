using BookingService.Domain.Interfaces.Repositories;
using BookingService.Persistence.Repositories;
using BookingService.Persistence.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BookingService.Persistence
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<BookingServiceDbContext>((dbService, options) =>
            {
                var setting = dbService.GetRequiredService<IOptions<DatabaseSetting>>().Value;

                options.UseNpgsql(setting.ConnectionString);
            });

            services.AddScoped<IBookingPlaceRepository, BookingPlaceRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<IHallRepository, HallRepository>();

            return services;
        }
    }
}
