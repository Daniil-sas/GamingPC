using BookingService.Domain.Exceptions;

namespace BookingService.Domain.Exception
{
    public class InvalidSpecException(string message) : DomainException(message)
    {
    }
}
