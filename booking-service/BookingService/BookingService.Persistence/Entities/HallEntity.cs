namespace BookingService.Persistence.Entities
{
    public class HallEntity
    {
        public Guid Id { get; set; }
        public Guid BookingPlaceId { get; set; }
        public string Name { get; set; }
        public string FloorUrl { get; set; }
        public string ComputerSpec { get; set; }
        public decimal PricePerHour { get; set; }
        public List<SeatEntity> Seats { get; set; }
        public BookingPlaceEntity BookingPlace { get; set; }
    }
}
