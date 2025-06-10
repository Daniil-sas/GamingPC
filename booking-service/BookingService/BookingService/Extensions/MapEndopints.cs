using BookingService.Controllers;

namespace BookingService.Extensions
{
    public static class MapEndopints
    {
        public static void AddMappedEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapBookingPlaceEndpoints();
            app.MapBookingEndpoints();
            app.MapSeatEndpoints();
            app.MapHallEndpoints();
        }
    }
}
