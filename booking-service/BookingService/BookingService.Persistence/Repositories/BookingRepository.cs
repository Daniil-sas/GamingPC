using AutoMapper;
using BookingService.Domain.Entities;
using BookingService.Domain.Interfaces.Repositories;
using BookingService.Domain.ValueObjects;
using BookingService.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Persistence.Repositories
{
    internal class BookingRepository : IBookingRepository
    {
        private readonly IMapper _mapper;
        private readonly BookingServiceDbContext _dbContext;
        public BookingRepository(BookingServiceDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public async Task<Guid> AddAsync(string userEmail, Guid seatId, TimeSlot slot)
        {
            var booking = new Booking(
                Guid.NewGuid(),
                seatId,
                userEmail,
                slot);

            var entity = _mapper.Map<BookingEntity>(booking);
            await _dbContext.Bookings.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return booking.Id;
        }

        public async Task<Booking> GetBookingByIdAsync(Guid bookingId)
        {
            var entity = await _dbContext.Bookings
                .FirstOrDefaultAsync(b => b.Id == bookingId);

            return entity != null ? _mapper.Map<Booking>(entity) : null;
        }

        public async Task<bool> IsSeatBooked(Guid seatId, TimeSlot timeSlot)
        {
            return await _dbContext.Bookings
                .AnyAsync(b => b.SeatId == seatId &&
                               b.StartTime < timeSlot.End &&
                               b.EndTime > timeSlot.Start);
        }
    }
}
