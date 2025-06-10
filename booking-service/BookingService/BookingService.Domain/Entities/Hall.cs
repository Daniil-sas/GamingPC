using BookingService.Domain.Common;
using BookingService.Domain.Exception;
using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Entities
{
    public class Hall : Entity
    {
        public Guid BookingPlaceId { get; set; }
        public string Name { get; set; }
        public string FloorUrl { get; set; }
        public decimal PricePerHour { get; set; }
        public ComputerSpec ComputerSpec { get; set; }
        public List<Seat> Seats { get; set; }

        private Hall() { }

        public Hall(Guid bookingPlaceId, string name, string floorUrl, decimal pricePerHour, ComputerSpec computerSpec)
        {
            Id = Guid.NewGuid();
            BookingPlaceId = bookingPlaceId;
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new InvalidHallException("Требуется название зала");
            FloorUrl = floorUrl;
            PricePerHour = pricePerHour > 0 ? pricePerHour : throw new InvalidHallException("Неккоректная цена в час");
            ComputerSpec = computerSpec;
        }

        public decimal CalculateCost(TimeSlot slot)
            => (decimal)slot.Duration.TotalHours * PricePerHour;

        public void AddSeat(Seat seat)
        {
            if (!Seats.Contains(seat))
                Seats.Add(seat);
        }
    }
}
