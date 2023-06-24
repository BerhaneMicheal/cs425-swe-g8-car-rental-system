using System;
using System.Net.NetworkInformation;
using CarRentalSystem.Data;
using CarRentalSystem.DTOs;
using CarRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Services.Implementations
{
	public class CarService:ICarService
	{
        private readonly AppDbContext db;
        private readonly IWebHostEnvironment hostEnvironment;

        public CarService(AppDbContext db, IWebHostEnvironment hostEnvironment)
		{
            this.db = db;
            this.hostEnvironment = hostEnvironment;
        }

        public async Task CreateCar(CarRequestDTO carRequest) {
            var imagePath = SaveFile(carRequest.CarImage);
            var car = new Car {
                CarImages = new List<CarImage> {
                    new CarImage{ImagePath=imagePath}
                },
                CarTypeId = carRequest.CarTypeId,
                Color = carRequest.Color,
                Mileage = carRequest.Mileage,
                Vin = carRequest.Vin,
                Status = Constants.CAR_STATUS_AVAILABLE
            };
            await db.Cars.AddAsync(car);
            await db.SaveChangesAsync();
        }

        private string SaveFile(IFormFile file) {
            string uploadPath = Path.Combine(hostEnvironment.WebRootPath, "uploads");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var extension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString() + extension;
            var filePath = Path.Combine(uploadPath, fileName);
            
            using (FileStream fs = File.Create(filePath))
            {
                file.CopyTo(fs);
            }

            return "/uploads/" + fileName;
        }

        private void deleteFile(string path) {
            string filePath = Path.Combine(hostEnvironment.WebRootPath, path);
            if (File.Exists(filePath)) {
                File.Delete(path);
            }
        }

        public async Task DeleteCar(int carId)
        {
            var car = await db.Cars.Include(c=>c.CarImages).FirstOrDefaultAsync(c=> c.Id == carId);
            if (car!=null)
            {
                deleteFile(car.CarImages.First().ImagePath);
                db.Cars.Remove(car);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Car?> GetCarById(int carId)
        {
            return await db.Cars
                .Include(c => c.CarImages)
                .Include(c=>c.CarType)
                .Include(c=> c.Rentals)
                .ThenInclude(r=> r.Review)
                //.ThenInclude(r2=> r2!.Rental)
                .Include(r=> r.Rentals)
                .ThenInclude(r=>r.Customer)
                .FirstOrDefaultAsync(c => c.Id == carId);
        }

        public async Task<IEnumerable<CarType>> GetCarTypes()
        {
            return await Task.FromResult(db.CarTypes.AsEnumerable());
        }


        public async Task UpdateCar(CarRequestDTO carRequest)
        {
            var _car = await db.Cars.FindAsync(carRequest.Id);
            if (_car != null)
            {
                _car.CarTypeId = carRequest.CarTypeId;
                _car.Color = carRequest.Color;
                _car.Mileage = carRequest.Mileage;
                _car.Vin = carRequest.Vin;
                _car.Status = carRequest.Status;

                if(carRequest.CarImage != null) {
                    var imagePath = SaveFile(carRequest.CarImage);
                    var image = _car.CarImages.First();
                    _car.CarImages.Remove(image);
                    _car.CarImages.Add(new CarImage
                    {
                        ImagePath = imagePath,
                        CarId = _car.Id
                    });
                }
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Car>> getAllCars()
        {
            return await Task.FromResult(db.Cars.Include(c=>c.CarType).Include(c=>c.CarImages).AsEnumerable());
        }

        public async Task<IEnumerable<Car>> getAllCarsByStatus(string status)
        {
            return await Task.FromResult(db.Cars.Where(c => c.Status == status));
        }

        public async Task<IEnumerable<Car>> getCarCatalog()
        {
            var cars =  db.Cars.Include(c=>c.CarImages).Include(c=>c.CarType).Where(c => c.Status == Constants.CAR_STATUS_AVAILABLE || c.Status == Constants.CAR_STATUS_RENTED).AsEnumerable();
            return await Task.FromResult(cars);
        }
    }
}

