using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Aggregates
{
    public class BookingPlace
    {
        private BookingPlace(Guid id, Hall[] halls, Address address)
        {
            Halls = halls;
            Address = address;
            Id = id;
        }
        public BookingPlace()
        {

        }

        public Guid Id { get; }
        public Hall[] Halls { get; }
        public Address Address { get; }

        public static BookingPlace Create(Guid id, Hall[] halls, Address address)
        {
            return new BookingPlace(id, halls, address);
        }
    }
}
