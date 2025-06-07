using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Exceptions
{
    public class SeatAlreadyBookedException(Guid seatId, TimeSlot slot) : DomainException($"Место {seatId} уже забронирвано по этому промежутку {slot.Start}-{slot.End}")
    {
    }
}
