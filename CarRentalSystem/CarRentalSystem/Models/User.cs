using System;
namespace CarRentalSystem.Models
{
	public class User
	{
		public User()
		{
		}

        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}

