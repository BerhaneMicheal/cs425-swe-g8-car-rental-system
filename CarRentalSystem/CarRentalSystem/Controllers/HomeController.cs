using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarRentalSystem.Models;
using CarRentalSystem.Services;

namespace CarRentalSystem.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICarService carService;

    public HomeController(ILogger<HomeController> logger, ICarService carService)
    {
        _logger = logger;
        this.carService = carService;
    }

    public async Task<IActionResult> Index()
    {
        var cars = (await carService.getCarCatalog()).ToList();
        return View(cars);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

