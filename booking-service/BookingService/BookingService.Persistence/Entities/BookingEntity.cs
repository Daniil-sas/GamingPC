namespace BookingService.Persistence.Entities
{
    public class BookingEntity
    {
        public Guid Id { get; set; }
        public Guid SeatId { get; set; }
        public string UserEmail { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public SeatEntity Seat { get; set; }
    }
}
