using BookingService.Domain.Aggregates;
using BookingService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<BookingPlace> BookingPlaces { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
