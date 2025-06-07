using BookingService.Domain.Exceptions;
using BookingService.Domain.Interfaces.Repositories;
using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Interfaces.Services
{
    public class BookingValidatorService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingValidatorService(IBookingRepository bookingRepository)
            => _bookingRepository = bookingRepository;

        public async Task ValidateBookingCreation(Guid seatId, TimeSlot slot)
        {
            if (await _bookingRepository.IsSeatBooked(seatId, slot))
                throw new SeatAlreadyBookedException(seatId, slot);

            if (slot.Start < DateTime.UtcNow.AddHours(2))
                throw new InvalidBookingTimeException("Бронированиe минимум от 2 часов");
        }
    }
}
