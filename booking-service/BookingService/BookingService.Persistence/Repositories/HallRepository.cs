using AutoMapper;
using BookingService.Domain.Entities;
using BookingService.Domain.Interfaces.Repositories;
using BookingService.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Persistence.Repositories
{
    internal class HallRepository : IHallRepository
    {
        private readonly IMapper _mapper;
        private readonly BookingServiceDbContext _dbContext;
        public HallRepository(BookingServiceDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public async Task AddAsync(Hall hall)
        {
            var entity = _mapper.Map<HallEntity>(hall);
            await _dbContext.Halls.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Hall> GetByIdAsync(Guid hallId)
        {
            var entity = await _dbContext.Halls
                .Include(h => h.Seats)
                .FirstOrDefaultAsync(h => h.Id == hallId);

            return entity != null ? _mapper.Map<Hall>(entity) : null;
        }

        public async Task<IReadOnlyList<Hall>> GetHallsInBookingPlace(Guid bookingPlaceId)
        {
            var entities = await _dbContext.Halls
                .Where(h => h.BookingPlaceId == bookingPlaceId)
                .ToListAsync();

            return _mapper.Map<List<Hall>>(entities).AsReadOnly();
        }
    }
}
