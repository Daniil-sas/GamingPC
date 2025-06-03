using BookingService.Domain.Common;

namespace BookingService.Domain.ValueObjects
{
    public class TimeSlot : ValueObject
    {
        public TimeSlot(DateTime start, TimeSpan duration)
        {
            if (duration <= TimeSpan.FromHours(2) || duration > TimeSpan.FromHours(10))
            {
                throw new ArgumentException("Продолжительность броинрования от 2 до 10 часов");
            }

            Start = start;
            Duration = duration;
        }

        public DateTime Start { get; }
        public TimeSpan Duration { get; }

        public bool OverlapsWith(TimeSlot otherSlot)
        {
            var thisEnd = Start + Duration;
            var otherEnd = otherSlot.Start + otherSlot.Duration;

            return Start < otherEnd && otherSlot.Start < thisEnd;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Start;
            yield return Duration;
        }
    }
}
