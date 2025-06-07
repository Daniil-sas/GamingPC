using BookingService.Domain.Common;
using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Entities
{
    public class BookingPlace : Entity
    {
        public Address Address { get; set; }
        public IReadOnlyCollection<Guid> HallIds => _hallIds.AsReadOnly();

        private readonly List<Guid> _hallIds = new();

        public BookingPlace(Guid id, Address address)
        {
            Id = id;
            Address = address;
        }

        public void AddHall(Guid hallId)
        {
            if (!_hallIds.Contains(hallId))
                _hallIds.Add(hallId);
        }
    }
}
