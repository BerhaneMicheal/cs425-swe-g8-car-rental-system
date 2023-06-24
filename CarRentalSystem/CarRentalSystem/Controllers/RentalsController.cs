using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalSystem.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRentalSystem.Controllers
{
    public class RentalsController : Controller
    {
        private readonly IRentalService rentalService;

        public RentalsController(IRentalService rentalService)
        {
            this.rentalService = rentalService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var rentals = rentalService.GetAll().ToList();
            return View(rentals);
        }


        public async Task<IActionResult> CreateFromReservation(int reservationId) {
            await rentalService.CreateRentalFromReservation(reservationId);
            return RedirectToAction("Index");
        }
    }
}

