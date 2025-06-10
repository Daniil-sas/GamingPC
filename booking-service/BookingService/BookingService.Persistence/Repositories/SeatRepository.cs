using AutoMapper;
using BookingService.Domain.Entities;
using BookingService.Domain.Interfaces.Repositories;
using BookingService.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BookingService.Persistence.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly IMapper _mapper;
        private readonly BookingServiceDbContext _dbContext;
        public SeatRepository(BookingServiceDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(Seat seat)
        {
            var newSeat = new SeatEntity()
            {
                Id = seat.Id,
                HallId = seat.HallId,
                NumberInHall = seat.NumberInHall,
                PositionJson = JsonConvert.SerializeObject(seat.Position)
            };

            await _dbContext.Seats.AddAsync(newSeat);
            await _dbContext.SaveChangesAsync();

            return newSeat.Id;
        }

        public async Task<Seat> GetByIdAsync(Guid seatId)
        {
            var seatEntity = await _dbContext.Seats
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == seatId);

            return _mapper.Map<Seat>(seatEntity);
        }

        public async Task<List<Seat>> GetSeatsInHall(Guid hallId)
        {
            var allSeatEntity = await _dbContext.Seats
                .AsNoTracking()
                .Where(f => f.HallId == hallId)
                .ToListAsync();

            return _mapper.Map<List<Seat>>(allSeatEntity);
        }
    }
}
