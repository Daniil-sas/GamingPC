using BookingService.Application.Services;
using BookingService.Contracts;

namespace BookingService.Controllers
{
    public static class BookingPlaceController
    {
        public static IEndpointRouteBuilder MapBookingPlaceEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/places/booking_places", AllExistingBookingPlaces);
            app.MapGet("api/places/booking_halls/{id}", GetHallsFromBookingPlaceById);
            app.MapPost("apli/places/create_booking_place", CreateNewBookingPlace);

            return app;
        }

        private static async Task<IResult> AllExistingBookingPlaces(BookingPlaceService placeService)
        {
            var all = await placeService.GetAllBookingPlaces();
            return Results.Ok(all);
        }

        private static async Task<IResult> GetHallsFromBookingPlaceById(Guid id, BookingPlaceService placeService)
        {
            var bookingPlace = await placeService.GetAllHallFromPlace(id);
            return Results.Ok(bookingPlace);
        }

        private static async Task<IResult> CreateNewBookingPlace(BookingPlaceAddRequest addRequest, BookingPlaceService placeService)
        {
            await placeService.AddBookingPlace(new Domain.ValueObjects.Address(addRequest.Address.City, addRequest.Address.Street, addRequest.Address.House, addRequest.Address.PostalCode));
            return Results.Ok();
        }
    }
}
