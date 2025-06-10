using BookingService.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingService.Persistence.Configuration
{
    internal class BookingPlaceConfiguration : IEntityTypeConfiguration<BookingPlaceEntity>
    {
        public void Configure(EntityTypeBuilder<BookingPlaceEntity> builder)
        {
            builder.ToTable("booking_places");
            builder.HasKey(x => x.Id);

            builder.Property(bp => bp.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(bp => bp.Address)
                .HasColumnName("address")
                .HasColumnType("json")
                .IsRequired();

            builder.HasMany<HallEntity>(bp => bp.Halls)
                .WithOne(h => h.BookingPlace)
                .HasForeignKey(h => h.BookingPlaceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
