using BookingService.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingService.Persistence.Configuration
{
    internal class BookingConfiguration : IEntityTypeConfiguration<BookingEntity>
    {
        public void Configure(EntityTypeBuilder<BookingEntity> builder)
        {
            builder.ToTable("bookings");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(b => b.SeatId)
                .HasColumnName("seat_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(b => b.UserEmail)
                .HasColumnName("user_email")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(b => b.StartTime)
                .HasColumnName("start_time")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(b => b.EndTime)
                .HasColumnName("end_time")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(b => b.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne<SeatEntity>(b => b.Seat)
                .WithMany(s => s.Bookings)
                .HasForeignKey(b => b.SeatId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
