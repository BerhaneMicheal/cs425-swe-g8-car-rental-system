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
    public class CarsController : Controller
    {
        private readonly ICarService carService;

        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var cars = (await carService.getAllCars()).ToList();
            return View(cars);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.carTypes = (await carService.GetCarTypes()).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarRequestDTO carRequestDTO)
        {
            await carService.CreateCar(carRequestDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var car = await carService.GetCarById(id);
            if (car == null) return NotFound();

            ViewBag.carTypes = (await carService.GetCarTypes()).ToList();
            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarRequestDTO carRequestDTO)
        {
            await carService.UpdateCar(carRequestDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await carService.DeleteCar(id);
            return RedirectToAction("Index");
        }

       
        public async Task<IActionResult> ViewCar(int id) {
            var car = await carService.GetCarById(id);
            if (car == null) return NotFound();
            
            return View(car);
        }
    }
}

