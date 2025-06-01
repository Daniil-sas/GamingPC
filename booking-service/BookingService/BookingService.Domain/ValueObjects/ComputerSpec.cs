using BookingService.Domain.Interfaces;

namespace BookingService.Domain.ValueObjects
{
    public record ComputerSpec(string[] Monitors, string Processor, string Chair,
        string RAM, string Keyboard, string Internet, string Mouse, string Disk, string GraphicsCard) : IValueObject;
}
