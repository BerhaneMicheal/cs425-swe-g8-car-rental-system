using System;
namespace CarRentalSystem.DTOs
{
	public class CarRequestDTO
	{
		public CarRequestDTO()
		{
		}

        public int Id { get; set; }
        public string Vin { get; set; } = default!;
        public string Color { get; set; } = default!;
        public int Mileage { get; set; } = default!;
        public string Status { get; set; } = default!;

        public int CarTypeId { get; set; }
        public IFormFile CarImage { get; set; } = default!;
    }
}

