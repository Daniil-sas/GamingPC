using BookingService.Domain.ValueObjects;

namespace BookingService.Persistence.Entities
{
    public class HallEntity
    {
        public Guid Id { get; set; }
        public Guid BookingPlaceId { get; set; }
        public string floorUrl { get; set; }
        public string Name { get; set; }
        public ComputerSpec ComputerSpec { get; set; }
        public decimal PricePerHour { get; set; }
        public ICollection<SeatEntity> Seats { get; set; } = [];
        public BookingPlaceEntity BookingPlace { get; set; }
    }
}
