namespace BookingService.Domain.Common
{
    public abstract class Entity
    {
        public Guid Id { get; }

        protected Entity()
        {
            Id = new Guid();
        }
        protected Entity(Guid id)
        {
            Id = id;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            var other = (Entity)obj;
            return Id == other.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
