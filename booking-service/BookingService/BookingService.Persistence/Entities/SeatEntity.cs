namespace BookingService.Persistence.Entities
{
    public class SeatEntity
    {
        public Guid Id { get; set; }
        public Guid HallId { get; set; }
        public int NumberInHall { get; set; }
        public string PositionJson { get; set; }
        public HallEntity Hall { get; set; }
        public ICollection<BookingEntity> Bookings { get; set; } = new List<BookingEntity>();
    }
}
