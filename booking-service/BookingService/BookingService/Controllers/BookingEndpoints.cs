using BookingService.Application.Services;
using BookingService.Contracts;

namespace BookingService.Controllers
{
    public static class BookingEndpoints
    {
        public static IEndpointRouteBuilder MapBookingEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/booking/create_booking", CreateNewBooking);
            app.MapPost("api/booking/books/{seatId}", SeatIsBooked);

            return app;
        }

        private static async Task<IResult> CreateNewBooking(BookingAddRequest bookingAddRequest, BookingsService bookingsService)
        {
            var bookingId = await bookingsService.CreateBooking(
                bookingAddRequest.UserEmail,
                bookingAddRequest.SeatId,
                new Domain.ValueObjects.TimeSlot(bookingAddRequest.Start, bookingAddRequest.End));

            return Results.Ok();
        }

        private static async Task<IResult> SeatIsBooked(Guid seatId, SeatIsBookedRequest seatIsBooked, BookingsService bookingsService)
        {
            var booked = await bookingsService.SeatIsBooked(seatId, new Domain.ValueObjects.TimeSlot(seatIsBooked.Start, seatIsBooked.End));

            return Results.Ok(booked);
        }
    }
}
