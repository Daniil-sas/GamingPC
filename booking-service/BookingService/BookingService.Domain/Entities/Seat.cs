namespace BookingService.Domain.Models
{
    public class Seat
    {
        private Seat(int id, int x, int y, int rotate, bool isOccuped, int numSeat)
        {
            Id = id;
            X = x;
            Y = y;
            Rotate = rotate;
            IsOccuped = isOccuped;
            NumSeat = numSeat;
        }
        public Seat()
        {

        }
        public int Id { get; }
        public int NumSeat { get; }
        public int X { get; }
        public int Y { get; }
        public int Rotate { get; }
        public bool IsOccuped { get; }
        public static Seat Create(int id, int x, int y, int rotate, bool isOccuped, int numSeat)
        {
            return new Seat(id, x, y, rotate, isOccuped, numSeat);
        }
    }
}
