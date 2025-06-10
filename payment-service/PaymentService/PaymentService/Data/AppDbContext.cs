using Microsoft.EntityFrameworkCore;
using PaymentService.Models.Entities;

namespace PaymentService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Payment> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.BookingId).HasColumnType("uuid");
                entity.Property(e => e.CardNumber).HasMaxLength(20);
                entity.Property(e => e.CardHolder).HasMaxLength(100);
                entity.Property(e => e.ExpiryDate).HasMaxLength(7);
                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.QrContent).HasColumnType("text");
                entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
            });
        }
    }
}
