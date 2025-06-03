using BookingService.Domain.Common;
using BookingService.Domain.Events;
using BookingService.Domain.Exceptions;
using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Aggregates
{
    public class BookingPlace : AggregateRoot
    {
        private BookingPlace(List<Hall> halls, Address address)
        {
            Halls = halls;
            Address = address;
        }
        public BookingPlace()
        {

        }

        public List<Hall> Halls { get; }
        public Address Address { get; }

        public void AddHall(Hall hall)
        {
            if (Halls.Any(h => h.Name == hall.Name))
                throw new HallConflictException($"Зал {hall.Name} с таким имененм уже существует");

            Halls.Add(hall);
            AddDomainEvent(new HallAddeedEvent { Id = hall.Id, PlaceId = Id, HallName = hall.Name });
        }

        public static BookingPlace Create(List<Hall> halls, Address address)
        {
            return new BookingPlace(halls, address);
        }
    }
}
