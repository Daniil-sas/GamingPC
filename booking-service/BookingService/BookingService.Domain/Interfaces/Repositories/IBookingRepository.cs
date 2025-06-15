using BookingService.Domain.Entities;
using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Interfaces.Repositories
{
    public interface IBookingRepository
    {
        Task<Guid> AddAsync(string userEmail, Guid seatId, TimeSlot slot);
        Task<bool> IsSeatBooked(Guid seatId, TimeSlot timeSlot);
        Task<Booking> GetBookingByIdAsync(Guid bookingId);
    }
}
