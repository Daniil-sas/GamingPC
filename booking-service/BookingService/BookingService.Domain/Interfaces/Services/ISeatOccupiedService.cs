using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Interfaces.Services
{
    public interface ISeatOccupiedService
    {
        Task<bool> IsSeatOccuped(Guid seatId, TimeSlot timeSlot);
    }
}
