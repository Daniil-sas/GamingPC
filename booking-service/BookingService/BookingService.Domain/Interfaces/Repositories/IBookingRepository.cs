using BookingService.Domain.Entities;
using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Interfaces.Repositories
{
    public interface IBookingRepository
    {
        Task<Guid> AddAsync(Guid userId, Guid bookingPlaceId, Guid hallId, Guid seatId, TimeSlot slot);
        Task<bool> IsSeatBooked(Guid seatId, TimeSlot timeSlot);
        Task<Booking> GetBookingByIdAsync(Guid bookingId);
    }
}
