using BookingService.Domain.Common;

namespace BookingService.Domain.ValueObjects
{
    public class ComputerSpec : ValueObject
    {
        public ComputerSpec(IReadOnlyList<string> monitors, string processor, string chair, string rAM, string keyboard, string internet, string mouse, string disk, string graphicsCard)
        {
            Monitors = monitors;
            Processor = processor;
            Chair = chair;
            RAM = rAM;
            Keyboard = keyboard;
            Internet = internet;
            Mouse = mouse;
            Disk = disk;
            GraphicsCard = graphicsCard;
        }

        public IReadOnlyList<string> Monitors { get; set; }
        public string Processor { get; set; }
        public string Chair { get; set; }
        public string RAM { get; set; }
        public string Keyboard { get; set; }
        public string Internet { get; set; }
        public string Mouse { get; set; }
        public string Disk { get; set; }
        public string GraphicsCard { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            foreach (var monitor in Monitors) yield return monitor;
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
