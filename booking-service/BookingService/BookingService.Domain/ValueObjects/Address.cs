using BookingService.Domain.Common;

namespace BookingService.Domain.ValueObjects
{
    public class Address(string city, string street, string house, string postCode) : ValueObject
    {
        public string City { get; } = city;
        public string Street { get; } = street;
        public string House { get; } = house;
        public string PostCode { get; } = postCode;
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return Street;
            yield return House;
            yield return PostCode;
        }
    }
}
