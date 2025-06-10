using BookingService.Domain.Common;

namespace BookingService.Domain.ValueObjects
{
    public class Address(string city, string street, string house, string postalCode) : ValueObject
    {
        public string City { get; } = city;
        public string Street { get; } = street;
        public string House { get; } = house;
        public string PostalCode { get; } = postalCode;
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return Street;
            yield return House;
            yield return PostalCode;
        }
    }
}
