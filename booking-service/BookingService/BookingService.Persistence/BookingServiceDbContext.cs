using BookingService.Persistence.Configuration;
using BookingService.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Persistence
{
    public class BookingServiceDbContext(DbContextOptions<BookingServiceDbContext> options)
        : DbContext(options)
    {
        public DbSet<SeatEntity> Seats { get; set; }
        public DbSet<HallEntity> Halls { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<BookingPlaceEntity> BookingsPlace { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SeatConfiguration());
            modelBuilder.ApplyConfiguration(new HallConfiguration());
            modelBuilder.ApplyConfiguration(new BookingPlaceConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
