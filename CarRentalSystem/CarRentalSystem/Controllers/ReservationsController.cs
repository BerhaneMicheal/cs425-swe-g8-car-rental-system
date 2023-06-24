using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalSystem.Models;
using CarRentalSystem.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRentalSystem.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationService reservationService;
        private readonly ICarService carService;

        public ReservationsController(IReservationService reservationService,
            ICarService carService)
        {
            this.reservationService = reservationService;
            this.carService = carService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var reservations = (await reservationService.getAll()).ToList();

            return View(reservations);
        }

        public async Task<IActionResult> New(int carId)
        {
            var locations = reservationService.GetPickupLocations().ToList();
            var car = await carService.GetCarById(carId);

            ViewBag.locations = locations;
            ViewBag.car = car;
            return View();
        }

        public IActionResult Success(string code, string carName) {
            ViewBag.code = code;
            ViewBag.carName = carName;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(Reservation reservation)
        {
            var code = await reservationService.CreateReservation(reservation);
            var car = await carService.GetCarById(reservation.CarId);

            return RedirectToAction("Success", new { code = code, carName = car!.CarType.Name });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var locations = reservationService.GetPickupLocations().ToList();
            var reservation = await reservationService.GetById(id);

            ViewBag.locations = locations;
            return View(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Reservation reservation)
        {
            await reservationService.UpdateReservation(reservation);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Cancel(int id)
        {
            await reservationService.Cancel(id);

            return RedirectToAction("Index");
        }

    }
}

