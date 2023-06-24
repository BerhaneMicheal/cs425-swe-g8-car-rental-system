using System;
namespace CarRentalSystem.Models
{
	public class CarType
	{
		public CarType()
		{
		}

        public int Id { get; set; }
        public string Brand { get; set; } = default!;
        public string Model { get; set; } = default!; 
        public int Year { get; set; } = default!;
        public decimal PricePerDay { get; set; } = default!; 
        public int MaxDuration { get; set; } = default!;

        public string Name { get {
                return Brand + " " + Model + " " + Year;
            } }

        public virtual ICollection<Car> Cars { get; set; } = default!;
    }
}

