using System;
namespace CarRentalSystem.Models
{
	public class Address
	{
		public Address()
		{
		}

		public int Id { get; set; }
		public string Street { get; set; } = default!;
		public string City { get; set; } = default!;
        public string? ZipCode { get; set; }
		public string State { get; set; } = default!;

		public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = default!;
    }
}

