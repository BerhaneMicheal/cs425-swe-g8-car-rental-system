using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalSystem.Models
{
	public class Customer
	{
		public Customer()
		{
		}

		public int Id { get; set; }
		public string FirstName { get; set; } = default!;
		public string LastName { get; set; } = default!;
		public string Email { get; set; } = default!;
		public string? Phone { get; set; }
		public string Password { get; set; } = default!;
		public string? DriverLicenceNumber { get; set; }

		[NotMapped]
		public string Name
		{
			get
			{
				return $"{FirstName} {LastName}";
			}
		}


		public virtual Address Address { get; set; } = default!;
		public virtual ICollection<Reservation> Reservations { get; set; } = default!;
		public virtual ICollection<Rental> Rentals { get; set; } = default!;
		
	}
}

