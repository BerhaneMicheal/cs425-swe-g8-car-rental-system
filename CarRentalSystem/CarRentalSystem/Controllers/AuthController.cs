using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalSystem.DTOs;
using CarRentalSystem.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRentalSystem.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginData)
        {
            try
            {
                await authService.LoginCustomer(loginData);
                return RedirectToAction("Index", new { controller = "Home" });
            }catch(UnauthorizedAccessException ex) {
                return View(ex.Message);
            }
            
        }

        [HttpGet]
        public IActionResult Logout()
        {
            authService.ClearSession();
            return RedirectToAction("Index");
        }
    }
}

