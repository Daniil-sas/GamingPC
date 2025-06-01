using BookingService.Domain.Interfaces;

namespace BookingService.Domain.ValueObjects
{
    public record Address(string City, string Street, string House, string Index) : IValueObject;
}
