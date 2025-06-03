namespace BookingService.Domain.Exceptions
{
    public class SeatPositionConflictException(string message) : BookingDomainException(message) { }
}
