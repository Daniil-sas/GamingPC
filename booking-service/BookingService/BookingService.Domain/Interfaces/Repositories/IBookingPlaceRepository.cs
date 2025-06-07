using BookingService.Domain.Entities;

namespace BookingService.Domain.Interfaces.Repositories
{
    public interface IBookingPlaceRepository
    {
        Task AddAsync(BookingPlace bookingPlace);
        Task<BookingPlace> GetByIdAsync(Guid placeId);
    }
}
