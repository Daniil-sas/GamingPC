using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Interfaces.Services
{
    public interface IBookingPolicyService
    {
        Task<bool> IsValidBookingTime(TimeSlot timeSlot);
    }
}
