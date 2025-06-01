using BookingService.Domain.Interfaces;

namespace BookingService.Domain.ValueObjects
{
    public class TimeSlot : IValueObject
    {
        public TimeSlot(DateTime start, DateTime end)
        {
            if (start <= end)
            {
                throw new InvalidTimeZoneException("Неверные временные рамки");
            }

            Start = start;
            End = end;
        }

        public DateTime Start { get; }
        public DateTime End { get; }
    }
}
