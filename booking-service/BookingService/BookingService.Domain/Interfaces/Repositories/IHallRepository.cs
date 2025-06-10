using BookingService.Domain.Entities;
using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Interfaces.Repositories
{
    public interface IHallRepository
    {
        Task<Guid> AddAsync(Hall hall);
        Task<Hall> GetByIdAsync(Guid hallId);
        Task<List<Hall>> GetHallsInBookingPlace(Guid bookingPlaceId);
        Task<bool> IsSeatBooked(Guid seatId, TimeSlot timeSlot);
    }
}
