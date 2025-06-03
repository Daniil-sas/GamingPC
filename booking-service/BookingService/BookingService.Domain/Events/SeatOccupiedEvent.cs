using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Events
{
    public class SeatOccupiedEvent
    {
        public Guid Id { get; set; }
        public TimeSlot? TimeSlot { get; set; }
    }
}
