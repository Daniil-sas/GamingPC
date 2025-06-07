namespace BookingService.Domain.Exceptions
{
    public class InvalidTimeSlotException(string message) : DomainException(message)
    {
    }
}
