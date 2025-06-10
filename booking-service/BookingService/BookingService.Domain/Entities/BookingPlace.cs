using BookingService.Domain.Common;
using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Entities
{
    public class BookingPlace : Entity
    {
        public Address Address { get; set; }
        public List<Hall> Halls { get; set; }

        public BookingPlace(Guid id, Address address)
        {
            Id = id;
            Address = address;
        }

        public void AddHall(Hall hall)
        {
            if (!Halls.Contains(hall))
                Halls.Add(hall);
        }
    }
}
