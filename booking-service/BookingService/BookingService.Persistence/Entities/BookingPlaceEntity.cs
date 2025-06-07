namespace BookingService.Persistence.Entities
{
    public class BookingPlaceEntity
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public ICollection<HallEntity> Halls { get; set; } = [];
    }
}
