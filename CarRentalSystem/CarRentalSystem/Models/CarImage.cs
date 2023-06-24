using System;
namespace CarRentalSystem.Models
{
	public class CarImage
	{
		public CarImage()
		{
		}

        public int Id { get; set; }
		public string ImagePath { get; set; } = default!;

        public int CarId { get; set; }
        public virtual Car Car { get; set; } = default!;
    }
}

