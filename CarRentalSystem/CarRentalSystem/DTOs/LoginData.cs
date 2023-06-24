using System;
namespace CarRentalSystem.DTOs
{
	public class LoginData
	{
		public LoginData()
		{
		}

		public int Id { get; set; }
		public string Email { get; set; } = default!;
		public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;

		public string Name => $"{FirstName} {LastName}";
    }
}

