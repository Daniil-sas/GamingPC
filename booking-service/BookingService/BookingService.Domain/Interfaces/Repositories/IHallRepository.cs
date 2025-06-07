using BookingService.Domain.Entities;

namespace BookingService.Domain.Interfaces.Repositories
{
    public interface IHallRepository
    {
        Task AddAsync(Hall hall);
        Task<Hall> GetByIdAsync(Guid hallId);
        Task<IReadOnlyList<Hall>> GetHallsInBookingPlace(Guid bookingPlaceId);
    }
}
