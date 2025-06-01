using BookingService.Domain.Interfaces;

namespace BookingService.Domain.ValueObjects
{
    public record SeatPosition(int X, int Y, int Rotate) : IValueObject;
}
