using BookingService.Domain.Aggregates;
using BookingService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingService.Persistence.Configuration
{
    public class BookingPlaceConfiguration : IEntityTypeConfiguration<BookingPlace>
    {
        public void Configure(EntityTypeBuilder<BookingPlace> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Address)
                .HasConversion(
                    v => $"{v.City},{v.Street},{v.House},{v.PostCode}",
                    v => ParseAddress(v))
                .HasMaxLength(512);

            builder.OwnsMany(x => x.Halls, h =>
            {
                h.WithOwner().HasForeignKey("BookingPlaceId");
                h.Property<Guid>("Id").ValueGeneratedNever();
                h.HasKey("Id");
            });
        }

        private static Address ParseAddress(string value)
        {
            var parts = value.Split(',');
            return new Address(parts[0], parts[1], parts[2], parts[3]);
        }
    }
}
