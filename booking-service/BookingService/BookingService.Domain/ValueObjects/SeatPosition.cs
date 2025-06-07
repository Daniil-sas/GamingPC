using BookingService.Domain.Common;

namespace BookingService.Domain.ValueObjects
{
    public class SeatPosition : ValueObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Rotation { get; set; }

        public SeatPosition()
        {

        }
        public SeatPosition(int x, int y, double rotation)
        {
            X = x;
            Y = y;
            Rotation = rotation;
        }

        public override string ToString()
        {
            return $"{X},{Y},{Rotation}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is SeatPosition other)
            {
                return X == other.X && Y == other.Y && Rotation == other.Rotation;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Rotation);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return X;
            yield return Y;
        }
    }
}
