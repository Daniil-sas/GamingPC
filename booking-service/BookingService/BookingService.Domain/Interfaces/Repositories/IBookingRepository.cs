using BookingService.Domain.Entities;
using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Interfaces.Repositories
{
    public interface IBookingRepository
    {
        Task AddAsync(Booking booking);
        Task<bool> IsSeatBooked(Guid seatId, TimeSlot timeSlot);
        Task<Booking> GetBookingByIdAsync(Guid bookingId);
    }
}
