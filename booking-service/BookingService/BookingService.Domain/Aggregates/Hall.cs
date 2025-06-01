using BookingService.Domain.Models;
using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Aggregates
{
    public class Hall
    {
        private Hall(int id, string name, string floorPlanUrl, double pricePerHouse, Seat[] seats, ComputerSpec computer)
        {
            Id = id;
            Name = name;
            FloorPlanUrl = floorPlanUrl;
            PricePerHouse = pricePerHouse;
            Seats = seats;
            Computer = computer;
        }
        public Hall()
        {

        }

        public int Id { get; }
        public string Name { get; } = string.Empty;
        public string FloorPlanUrl { get; } = string.Empty;
        public double PricePerHouse { get; }
        public Seat[] Seats { get; }
        public ComputerSpec Computer { get; }

        public static Hall Create(int id, string name, string floorPlanUrl, double pricePerHouse, Seat[] seat, ComputerSpec computer)
        {
            return new Hall(id, name, floorPlanUrl, pricePerHouse, seat, computer);
        }
    }
}
