using BookingService.Domain.Entities;

namespace BookingService.Domain.Interfaces.Repositories
{
    public interface ISeatRepository
    {
        Task AddAsync(Seat seat);
        Task<Seat> GetByIdAsync(Guid seatId);
        Task<IReadOnlyList<Seat>> GetSeatsInHall(Guid hallId);
    }
}
