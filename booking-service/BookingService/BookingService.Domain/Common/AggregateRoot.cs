using BookingService.Domain.Events;

namespace BookingService.Domain.Common
{
    public abstract class AggregateRoot : Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        protected AggregateRoot() : base() { }
        protected AggregateRoot(Guid id) : base(id) { }
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
        protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
        protected void CleanDomainEvents() => _domainEvents.Clear();
    }
}
