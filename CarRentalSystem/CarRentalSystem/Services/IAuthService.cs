using System;
using CarRentalSystem.DTOs;

namespace CarRentalSystem.Services
{
	public interface IAuthService
	{
        Task LoginCustomer(LoginDTO login);
        LoginData? GetLoginData();
        bool IsLoggedIn();
        void ClearSession();
    }
}

