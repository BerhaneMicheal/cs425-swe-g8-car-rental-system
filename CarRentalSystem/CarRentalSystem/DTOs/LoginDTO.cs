using System;
namespace CarRentalSystem.DTOs
{
	public class LoginDTO
	{
		public LoginDTO()
		{}
		public string Email { get; set; } = default!;
		public string Password { get; set; } = default!;
    }
}

