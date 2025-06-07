using AutoMapper;
using BookingService.Domain.Entities;
using BookingService.Domain.Interfaces.Repositories;
using BookingService.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Persistence.Repositories
{
    internal class BookingPlaceRepository : IBookingPlaceRepository
    {
        private readonly IMapper _mapper;
        private readonly BookingServiceDbContext _dbContext;
        public BookingPlaceRepository(BookingServiceDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public async Task AddAsync(BookingPlace bookingPlace)
        {
            var entity = _mapper.Map<BookingPlaceEntity>(bookingPlace);
            await _dbContext.BookingsPlace.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<BookingPlace> GetByIdAsync(Guid placeId)
        {
            var entity = await _dbContext.BookingsPlace
                .Include(bp => bp.Halls)
                .FirstOrDefaultAsync(bp => bp.Id == placeId);

            return entity != null ? _mapper.Map<BookingPlace>(entity) : null;
        }
    }
}
