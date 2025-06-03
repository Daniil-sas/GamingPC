using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Interfaces.Repositories
{
    public interface IBookingPlacePolicy
    {
        Task<bool> IsSeatPlaceValid(Guid seatId, TimeSlot timeSlot);
        Task BookSeat(Guid seatId, Guid userId, TimeSlot timeSlot);
        Task FreeSeat(Guid seatId, Guid userId, TimeSlot timeSlot);
    }
}
