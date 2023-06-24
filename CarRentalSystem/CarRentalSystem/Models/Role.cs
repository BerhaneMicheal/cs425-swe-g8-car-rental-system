using System;
namespace CarRentalSystem.Models
{
	public class Role
	{
		public Role()
		{
		}

        public int Id { get; set; }
        public string Title { get; set; } = default!;
    }
}

