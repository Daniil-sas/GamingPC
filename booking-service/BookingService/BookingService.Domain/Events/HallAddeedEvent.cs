namespace BookingService.Domain.Events
{
    public class HallAddeedEvent : IDomainEvent
    {
        public Guid Id { get; set; }
        public Guid PlaceId { get; set; }
        public string HallName { get; set; } = string.Empty;
    }
}
