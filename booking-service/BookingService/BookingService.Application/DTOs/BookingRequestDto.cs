using BookingService.Domain.ValueObjects;

namespace BookingService.Infrastructure.DTOs
{
    public class BookingRequestDto
    {
        public Guid UserId { get; set; }
        public Guid HallId { get; set; }
        public Guid SeatId { get; set; }
        public Guid BookingPlaceId { get; set; }
        public TimeSlot TimeSlot { get; set; }
    }
}
