using BookingService.Domain.Common;
using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Models
{
    public class Seat : Entity
    {
        private Seat(SeatPosition seatPosition, int numSeatInHall)
        {
            SeatPosition = seatPosition;
            NumSeatInHall = numSeatInHall;
        }
        public Seat()
        {

        }
        public SeatPosition SeatPosition { get; }
        public int NumSeatInHall { get; }
        public DateTime OccupiedTime { get; }

        public static Seat Create(SeatPosition seatPosition, int numSeatInHall)
        {
            return new Seat(seatPosition, numSeatInHall);
        }
    }
}
