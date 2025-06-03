namespace BookingService.Domain.Exceptions
{
    public class HallConflictException(string message) : BookingDomainException(message) { }
}
