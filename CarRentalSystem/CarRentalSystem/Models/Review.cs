using System;
namespace CarRentalSystem.Models
{
	public class Review
	{
		public Review()
		{
		}

        public int Id { get; set; }
        public string Comment { get; set; } = default!;
        public int Rating { get; set; } = default!; // 1 - 5

		public int RentalId { get; set; }
        public virtual Rental Rental { get; set; } = default!;
    }
}

