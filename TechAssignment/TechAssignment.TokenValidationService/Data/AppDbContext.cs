using Microsoft.EntityFrameworkCore;
using TechAssignment.TokenValidationService.Models;

namespace TechAssignment.TokenValidationService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("users");
                e.Property(e => e.Id).HasColumnName("id");
                e.Property(e => e.Username).HasColumnName("username");
                e.Property(e => e.PasswordHash).HasColumnName("passwordhash");
            });            
        }
    }
}
