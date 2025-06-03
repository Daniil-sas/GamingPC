using BookingService.Domain.Common;

namespace BookingService.Domain.ValueObjects
{
    public class Address(string City, string Street, string House, string PostCode) : ValueObject
    {
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return Street;
            yield return House;
            yield return PostCode;
        }
    }
}
