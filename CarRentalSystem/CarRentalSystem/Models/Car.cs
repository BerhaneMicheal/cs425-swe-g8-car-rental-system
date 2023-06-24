using System;
namespace CarRentalSystem.Models
{
	public class Car
	{
		public Car()
		{
		}

        public int Id { get; set; }
        public string Vin { get; set; } = default!;
        public string Color { get; set; } = default!;
        public int Mileage { get; set; } = default!;
        public string Status { get; set; } = default!;

        public int CarTypeId { get; set; }
        public virtual CarType CarType { get; set; } = default!;

        public virtual ICollection<CarImage> CarImages { get; set; } = default!;

        public virtual ICollection<Rental> Rentals { get; set; } = default!;
        public virtual ICollection<Reservation> Reservations { get; set; } = default!;

    }
}

