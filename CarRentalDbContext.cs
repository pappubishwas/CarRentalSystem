using Microsoft.EntityFrameworkCore;
using CarRentalSystem.Models;

namespace CarRentalSystem
{
    public class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options)
            : base(options)
        {
        }


        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Car>().ToTable("Cars");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Rental>().ToTable("Rentals");
        }
    }
}
