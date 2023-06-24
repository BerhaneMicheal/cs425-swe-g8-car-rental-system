using System;
namespace CarRentalSystem.Models
{
	public class Rental
	{
		public Rental()
		{
		}

        public int Id { get; set; }
        public DateTime StartDate { get; set; } = default!;
        public DateTime EndDate { get; set; } = default!;
        public decimal RentalFee { get; set; } = default!;
        public string? Status { get; set; } // Rented, Returned
        
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = default!;
        public virtual Review? Review { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; } = default!;

        public int? ReservationId { get; set; }
        public virtual Reservation? Reservation { get; set; }

        public int PickupLocationId { get; set; }
        public virtual PickupLocation PickupLocation { get; set; } = default!;
    }
}

