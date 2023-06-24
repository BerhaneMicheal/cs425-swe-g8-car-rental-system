using System;
namespace CarRentalSystem.Models
{
	public class PickupLocation
	{
		public PickupLocation()
		{
		}

        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string? ZipCode { get; set; }
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;

        public override string ToString() {
            return $"{Name} - {Street}, {ZipCode}, {City}, {State}";
        }
        public virtual ICollection<Reservation> Reservations { get; set; } = default!;

    }
}

