using BookingService.Domain.Aggregates;
using BookingService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingService.Persistence.Configuration
{
    public class HallConfiguration : IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne<BookingPlace>()
                .WithMany(p => p.Halls)
                .HasForeignKey(f => f.BookingPlaceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(h => h.FloorPlanUrl)
               .IsRequired(false)
               .HasMaxLength(512);

            builder.Property(h => h.PricePerHour)
                .HasColumnType("decimal(18,2)");

            builder.OwnsMany(h => h.Seats, seat =>
            {
                seat.WithOwner().HasForeignKey("HallId");
                seat.Property<Guid>("Id").ValueGeneratedNever();
                seat.HasKey("Id");
            });

            builder.Property(p => p.Computer)
                .HasConversion(
                    v => $"{ParseMonitors(v.Monitors)},{v.Internet},{v.Chair},{v.GraphicsCard},{v.Disk}," +
                    $"{v.Keyboard},{v.RAM}",
                );
        }

        private static string ParseMonitors(string[] monitors)
        {
            string retMon = monitors[0];
            for (int i = 1; i < monitors.Length; retMon += " " + monitors[i++]) ;
            return retMon;
        }

        private static ComputerSpec ParseComputer(string value)
        {
            var parts = value.Split(',');
            return new ComputerSpec(parts[0], parts[1], parts[2], parts[3]);
        }
    }
}
