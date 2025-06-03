using BookingService.Domain.Aggregates;

namespace BookingService.Domain.Interfaces.Repositories
{
    public interface IBookingPlaceRepository
    {
        Task<BookingPlace?> GetByIdAsync(Guid id);
        Task SaveChanges(BookingPlace place);
    }
}
