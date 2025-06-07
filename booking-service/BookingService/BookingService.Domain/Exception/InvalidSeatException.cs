using BookingService.Domain.Exceptions;

namespace BookingService.Domain.Exception
{
    public class InvalidSeatException(string message) : DomainException(message)
    {
    }
}
