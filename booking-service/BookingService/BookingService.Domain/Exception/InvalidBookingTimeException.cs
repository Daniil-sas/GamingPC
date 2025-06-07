namespace BookingService.Domain.Exceptions
{
    public class InvalidBookingTimeException(string message) : DomainException(message)
    {
    }
}
