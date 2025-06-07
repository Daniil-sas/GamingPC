using BookingService.Domain.ValueObjects;
using BookingService.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace BookingService.Persistence.Configuration
{
    internal class SeatConfiguration : IEntityTypeConfiguration<SeatEntity>
    {
        public void Configure(EntityTypeBuilder<SeatEntity> builder)
        {
            var jOption = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            builder.ToTable("seats");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(s => s.HallId)
                .HasColumnName("hall_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(s => s.NumberInHall)
                .HasColumnName("number_in_hall")
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(s => s.PositionJson)
                .HasColumnName("position")
                .HasColumnType("json")
                .IsRequired()
                .HasConversion(
                    v => JsonConvert.SerializeObject(v, jOption),
                    v => JsonConvert.DeserializeObject<SeatPosition>(v, jOption)!
                );

            builder.HasOne<HallEntity>(s => s.Hall)
                .WithMany(h => h.Seats)
                .HasForeignKey(s => s.HallId);

            builder.HasIndex(s => new { s.HallId, s.NumberInHall })
                .IsUnique()
                .HasDatabaseName("idx_seats_hall_number_unique");
        }
    }
}
