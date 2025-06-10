using BookingService.Application.Services;
using BookingService.Contracts;
using BookingService.Domain.ValueObjects;

namespace BookingService.Controllers
{
    public static class SeatEndpoints
    {
        public static IEndpointRouteBuilder MapSeatEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/seats/create", CreateSeat);
            app.MapGet("api/seats/by-hall/{hallId}", GetAllSeatsByHallId);

            return app;
        }

        private static async Task<IResult> CreateSeat(
            SeatAddRequest seatAddRequest,
            SeatService seatService)
        {
            var position = new SeatPosition(seatAddRequest.Position.X, seatAddRequest.Position.Y, seatAddRequest.Position.Rotation);

            var seatId = await seatService.CreateSeat(
                seatAddRequest.HallId,
                seatAddRequest.NumInHall,
                position
            );

            return Results.Ok(seatId);
        }

        private static async Task<IResult> GetAllSeatsByHallId(
            Guid hallId,
            SeatService seatService)
        {
            var seats = await seatService.GetAllSeatsByHallIdAsync(hallId);
            return Results.Ok(seats);
        }
    }
}
