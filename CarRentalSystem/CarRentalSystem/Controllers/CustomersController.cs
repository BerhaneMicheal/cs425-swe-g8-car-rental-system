using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalSystem.Models;
using CarRentalSystem.Services;
using CarRentalSystem.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRentalSystem.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var customers = (await customerService.GetAll()).ToList();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            await customerService.Create(customer);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var customer = await customerService.GetById(id);
            if (customer == null) return NotFound();
            
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Customer customer)
        {
            await customerService.Update(customer);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await customerService.Delete(id);
            return RedirectToAction("Index");
        }


    }
}

