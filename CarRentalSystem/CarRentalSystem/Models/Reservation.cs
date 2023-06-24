using System;
namespace CarRentalSystem.Models
{
	public class Reservation
	{
		public Reservation()
		{
		}

        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public DateTime StartDate { get; set; } = default!;
        public DateTime EndDate { get; set; } = default!;
        public decimal ReservationFee { get; set; } = default!;
        public string Status { get; set; } = default!; // Pending, Rented, Cancelled

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = default!;

        public int PickupLocationId { get; set; }
        public virtual PickupLocation PickupLocation { get; set; } = default!;

        public int CarId { get; set; }
        public virtual Car Car { get; set; } = default!;
    }
}

