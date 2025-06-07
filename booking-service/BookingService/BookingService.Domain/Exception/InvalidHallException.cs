using BookingService.Domain.Exceptions;

namespace BookingService.Domain.Exception
{
    public class InvalidHallException(string message) : DomainException(message)
    {
    }
}
