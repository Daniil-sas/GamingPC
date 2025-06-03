using BookingService.Domain.Common;

namespace BookingService.Domain.ValueObjects
{
    public class ComputerSpec(string[] Monitors, string Processor, string Chair,
        string RAM, string Keyboard, string Internet, string Mouse, string Disk, string GraphicsCard) : ValueObject
    {
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Monitors;
            yield return Processor;
            yield return Chair;
            yield return RAM;
            yield return Keyboard;
            yield return Internet;
            yield return Mouse;
            yield return Disk;
            yield return GraphicsCard;
        }
    }
}
