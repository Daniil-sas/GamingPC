using BookingService.Domain.Common;
using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Entities
{
    public class Booking : Entity
    {
        public Guid UserId { get; set; }
        public Guid SeatId { get; set; }
        public Guid HallId { get; set; }
        public Guid BookingPlaceId { get; set; }
        public TimeSlot Slot { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        private Booking()
        {

        }

        public Booking(Guid id, Guid userId, Guid seatId, Guid hallId, Guid bookingPlaceId, TimeSlot slot)
        {
            Id = id;
            UserId = userId;
            SeatId = seatId;
            HallId = hallId;
            BookingPlaceId = bookingPlaceId;
            Slot = slot;
        }
        public bool IsActive() => Slot.End > DateTime.UtcNow;
    }
}
