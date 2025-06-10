using BookingService.Domain.Entities;

namespace BookingService.Domain.Interfaces.Repositories
{
    public interface ISeatRepository
    {
        Task<Guid> AddAsync(Seat seat);
        Task<Seat> GetByIdAsync(Guid seatId);
        Task<List<Seat>> GetSeatsInHall(Guid hallId);
    }
}
