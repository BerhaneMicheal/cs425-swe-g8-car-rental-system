using System.Text.Json;
using CarRentalSystem.Data;
using CarRentalSystem.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Services.Implementations
{
    public class AuthService: IAuthService
    {
        private readonly AppDbContext db;
        private readonly IHttpContextAccessor accessor;

        public AuthService(AppDbContext db, IHttpContextAccessor accessor)
		{
            this.db = db;
            this.accessor = accessor;
        }

		public async Task LoginCustomer(LoginDTO login) {
			var customer = await db.Customers.Where(c => c.Email == login.Email && c.Password == login.Password).FirstOrDefaultAsync();
			if(customer == null) {
				throw new UnauthorizedAccessException("Invalid username or password");
			}
			else {
				var loginData = new LoginData {
					Id = customer.Id,
					Email = customer.Email,
					FirstName = customer.FirstName,
					LastName = customer.LastName
				};
				accessor.HttpContext!.Session.SetString("loginData", JsonSerializer.Serialize(loginData));
			}
		}

		public LoginData? GetLoginData() {
			var loginDataString = accessor.HttpContext!.Session.GetString("loginData");
			if (loginDataString == null) return null;
			else {
				return JsonSerializer.Deserialize<LoginData>(loginDataString);
			}
		}

		public bool IsLoggedIn() {
			return accessor.HttpContext!.Session.GetString("loginData") != null;

        }

		public void ClearSession() {
			accessor.HttpContext!.Session.Clear();
		}
	}
}

