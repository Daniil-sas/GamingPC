using BookingService.Domain.Common;
using BookingService.Domain.Exceptions;

namespace BookingService.Domain.ValueObjects
{
    public class TimeSlot : ValueObject
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        public TimeSpan Duration => End - Start;

        public TimeSlot(DateTime start, DateTime end)
        {
            if (start >= end) throw new InvalidTimeSlotException("Не корректная дата начала и конца броинрования");
            if (Duration <= TimeSpan.FromHours(2) || Duration > TimeSpan.FromHours(10)) throw new InvalidTimeSlotException("Бронирование от 2 до 10 часов");

            Start = start;
            End = end;
        }

        public bool OverlapsWith(TimeSlot other)
            => Start < other.End && End > other.Start;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Start;
            yield return End;
        }
    }
}
