using System;
using CarRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Data
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
		{
		}

		public DbSet<Address> Addresses { get; set; } = default!;
		public DbSet<Car> Cars { get; set; } = default!;
        public DbSet<CarImage> CarImages { get; set; } = default!;
        public DbSet<CarType> CarTypes { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<PickupLocation> PickupLocations { get; set; } = default!;
        public DbSet<Rental> Rentals { get; set; } = default!;
        public DbSet<Reservation> Reservations { get; set; } = default!;
        public DbSet<Review> Reviews { get; set; } = default!;
        public DbSet<Role> Roles { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;


    }
}

