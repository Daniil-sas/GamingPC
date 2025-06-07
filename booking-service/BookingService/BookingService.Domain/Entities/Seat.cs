using BookingService.Domain.Common;
using BookingService.Domain.Exception;
using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Entities
{
    public class Seat : Entity
    {
        public Guid HallId { get; }
        public int NumberInHall { get; }
        public SeatPosition Position { get; }

        private Seat() { }

        public Seat(Guid hallId, int numberInHall, SeatPosition position)
        {
            Id = Guid.NewGuid();
            HallId = hallId;
            NumberInHall = numberInHall > 0 ? numberInHall : throw new InvalidSeatException("Неверное номер места в зале");
            Position = position;
        }
    }
}
