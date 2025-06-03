using BookingService.Domain.Common;

namespace BookingService.Domain.ValueObjects
{
    public class SeatPosition(int X, int Y, int Rotate) : ValueObject
    {
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return X;
            yield return Y;
        }
    }
}
