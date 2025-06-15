using BookingService.Domain.Common;
using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Entities
{
    public class Booking : Entity
    {
        public Guid SeatId { get; set; }
        public string UserEmail { get; set; }
        public TimeSlot Slot { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        private Booking()
        {

        }

        public Booking(Guid id, Guid seatId, string userEmail, TimeSlot slot)
        {
            Id = id;
            UserEmail = userEmail;
            SeatId = seatId;
            Slot = slot;
        }
        public bool IsActive() => Slot.End > DateTime.UtcNow;
    }
}
