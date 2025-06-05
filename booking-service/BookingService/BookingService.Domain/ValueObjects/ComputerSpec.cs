using BookingService.Domain.Common;

namespace BookingService.Domain.ValueObjects
{
    public class ComputerSpec(string[] monitors, string processor, string chair,
        string ram, string keyboard, string internet, string mouse, string disk, string graphicsCard) : ValueObject
    {
        public string[] Monitors { get; } = monitors;
        public string Processor { get; } = processor;
        public string Chair { get; } = chair;
        public string RAM { get; } = ram;
        public string Keyboard { get; } = keyboard;
        public string Internet { get; } = internet;
        public string Mouse { get; } = mouse;
        public string Disk { get; } = disk;
        public string GraphicsCard { get; } = graphicsCard;
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return string.Join(",", Monitors.OrderBy(m => m));
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
