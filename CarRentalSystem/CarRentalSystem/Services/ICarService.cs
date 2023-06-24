using System;
using CarRentalSystem.DTOs;
using CarRentalSystem.Models;

namespace CarRentalSystem.Services
{
    public interface ICarService
    {
        Task<IEnumerable<CarType>> GetCarTypes();
        Task CreateCar(CarRequestDTO carRequest);
        Task UpdateCar(CarRequestDTO carRequest);
        Task<Car?> GetCarById(int carId);
        Task DeleteCar(int carId);
        Task<IEnumerable<Car>> getAllCars();
        Task<IEnumerable<Car>> getCarCatalog();
        Task<IEnumerable<Car>> getAllCarsByStatus(string status);
    }
}

