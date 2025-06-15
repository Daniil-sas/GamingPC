using BookingService.Domain.Interfaces.Repositories;
using BookingService.Domain.ValueObjects;

namespace BookingService.Application.Services
{
    public class BookingsService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingsService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<Guid> CreateBooking(string userEmail, Guid seatId, TimeSlot slot)
        {
            var booking_id = await _bookingRepository.AddAsync(userEmail, seatId, slot);

            return booking_id;
        }

        public async Task<bool> SeatIsBooked(Guid seatId, TimeSlot timeSlot)
        {
            var available = await _bookingRepository.IsSeatBooked(seatId, timeSlot);

            return available;
        }
    }
}
