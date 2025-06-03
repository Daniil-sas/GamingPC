using BookingService.Domain.Common;
using BookingService.Domain.Exceptions;
using BookingService.Domain.Models;
using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Aggregates
{
    public class Hall : Entity
    {
        private Hall(string name, string floorPlanUrl, double pricePerHouse, List<Seat> seats, ComputerSpec computer)
        {
            Name = name;
            FloorPlanUrl = floorPlanUrl;
            PricePerHouse = pricePerHouse;
            Seats = seats;
            Computer = computer;
        }
        public Hall()
        {

        }

        public string Name { get; } = string.Empty;
        public string FloorPlanUrl { get; } = string.Empty;
        public double PricePerHouse { get; }
        public List<Seat> Seats { get; }
        public ComputerSpec Computer { get; }

        public void AddSeat(Seat seat)
        {
            if (Seats.Any(s => s.SeatPosition == seat.SeatPosition))
                throw new SeatPositionConflictException("По таким координатам уже есть место");

            Seats.Add(seat);
        }

        public static Hall Create(string name, string floorPlanUrl, double pricePerHouse, List<Seat> seat, ComputerSpec computer)
        {
            return new Hall(name, floorPlanUrl, pricePerHouse, seat, computer);
        }
    }
}
