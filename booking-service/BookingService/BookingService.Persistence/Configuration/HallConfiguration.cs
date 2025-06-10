using BookingService.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace BookingService.Persistence.Configuration
{
    internal class HallConfiguration : IEntityTypeConfiguration<HallEntity>
    {
        public void Configure(EntityTypeBuilder<HallEntity> builder)
        {
            var jOption = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            builder.ToTable("halls");
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(h => h.BookingPlaceId)
                .HasColumnName("booking_place_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(h => h.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(h => h.PricePerHour)
                .HasColumnName("price_per_hour")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(h => h.ComputerSpec)
                .HasColumnName("computer_spec")
                .HasColumnType("json")
                .IsRequired()
                .HasConversion(
                    v => JsonConvert.SerializeObject(v, jOption),
                    v => v
                );

            builder.HasOne<BookingPlaceEntity>(h => h.BookingPlace)
                .WithMany(bp => bp.Halls)
                .HasForeignKey(h => h.BookingPlaceId);

            builder.HasMany<SeatEntity>(h => h.Seats)
                .WithOne(s => s.Hall)
                .HasForeignKey(s => s.HallId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
