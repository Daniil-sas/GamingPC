using BookingService.Application.Services;
using BookingService.Contracts;

namespace BookingService.Controllers
{
    public static class HallEndpoints
    {
        public static IEndpointRouteBuilder MapHallEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/halls/create", CreateHall);
            app.MapGet("api/halls/by-booking-place/{bookingPlaceId}", GetAllHallsByBookingPlaceId);

            return app;
        }

        private static async Task<IResult> CreateHall(
            HallAddRequest hallAddRequest,
            HallService hallService)
        {
            var hallId = await hallService.CreateHall(
                hallAddRequest.BookingPlaceId,
                hallAddRequest.Name,
                hallAddRequest.FloorUrl,
                hallAddRequest.ComputerSpec,
                hallAddRequest.PricePerHour
            );

            return Results.Ok(hallId);
        }

        private static async Task<IResult> GetAllHallsByBookingPlaceId(
            Guid bookingPlaceId,
            HallService hallService)
        {
            var halls = await hallService.GetAllHallsByBookingPlaceIdAsync(bookingPlaceId);
            return Results.Ok(halls);
        }
    }
}
