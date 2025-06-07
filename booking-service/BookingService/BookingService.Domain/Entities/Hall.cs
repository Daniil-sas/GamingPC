using BookingService.Domain.Common;
using BookingService.Domain.Exception;
using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Entities
{
    public class Hall : Entity
    {
        public Guid BookingPlaceId { get; }
        public string Name { get; }
        public string FloorUrl { get; }
        public decimal PricePerHour { get; }
        public ComputerSpec Specification { get; }
        public IReadOnlyCollection<Guid> SeatIds => _seatIds.AsReadOnly();

        private readonly List<Guid> _seatIds = new();

        private Hall() { }

        public Hall(Guid bookingPlaceId, string name, string floorUrl, decimal pricePerHour, ComputerSpec spec)
        {
            Id = Guid.NewGuid();
            BookingPlaceId = bookingPlaceId;
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new InvalidHallException("Требуется название зала");
            FloorUrl = floorUrl;
            PricePerHour = pricePerHour > 0 ? pricePerHour : throw new InvalidHallException("Неккоректная цена в час");
            Specification = spec;
        }

        public decimal CalculateCost(TimeSlot slot)
            => (decimal)slot.Duration.TotalHours * PricePerHour;

        public void AddSeat(Guid seatId)
        {
            if (!_seatIds.Contains(seatId))
                _seatIds.Add(seatId);
        }
    }
}
