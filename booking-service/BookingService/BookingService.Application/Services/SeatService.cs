using BookingService.Domain.Entities;
using BookingService.Domain.Interfaces.Repositories;
using BookingService.Domain.ValueObjects;

namespace BookingService.Application.Services
{
    public class SeatService
    {
        private readonly ISeatRepository _seatRepository;

        public SeatService(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<Guid> CreateSeat(Guid hallId, int numInHall, SeatPosition position)
        {
            var seat = new Seat(hallId, numInHall, position);
            var seatId = await _seatRepository.AddAsync(seat);

            return seatId;
        }

        public async Task<List<Seat>> GetAllSeatsByHallIdAsync(Guid hallId)
        {
            var seats = await _seatRepository.GetSeatsInHall(hallId);

            return seats;
        }
    }
}
