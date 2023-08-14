using Microsoft.EntityFrameworkCore;

namespace MotivWebApp.Models
{
    public class EntityDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Name);

            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Loan);
        }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MyDb");
        }
    }
}
