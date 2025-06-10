using AutoMapper;
using BookingService.Domain.Entities;
using BookingService.Domain.Interfaces.Repositories;
using BookingService.Domain.ValueObjects;
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
        public async Task<BookingPlace> AddAsync(Address address)
        {
            var newBookingPlace = new BookingPlace(Guid.NewGuid(), address);

            var entity = _mapper.Map<BookingPlaceEntity>(newBookingPlace);

            await _dbContext.BookingsPlace.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return newBookingPlace;
        }

        public async Task<List<BookingPlace>> GetAllAsync()
        {
            var entity = await _dbContext.BookingsPlace
                .ToListAsync();

            var r = _mapper.Map<List<BookingPlace>>(entity);

            return r;
        }

        public async Task<List<Hall>> GetByIdAsync(Guid placeId)
        {
            var entity = await _dbContext.BookingsPlace
                .Include(bp => bp.Halls)
                .FirstOrDefaultAsync(bp => bp.Id == placeId);

            return entity != null ? _mapper.Map<List<Hall>>(entity.Halls) : null;
        }
    }
}
