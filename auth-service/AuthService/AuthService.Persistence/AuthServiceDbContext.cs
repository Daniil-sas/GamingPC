using AuthService.Persistence.Configurations;
using AuthService.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Persistence
{
    public class AuthServiceDbContext(DbContextOptions<AuthServiceDbContext> options)
        : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
