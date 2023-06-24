using CarRentalSystem.Data;
using CarRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Services.Implementations
{
	public class RentalService: IRentalService
    {
        private readonly AppDbContext db;

        public RentalService(AppDbContext db)
		{
            this.db = db;
        }

        public async Task CreateRentalFromReservation(int reservationId) {
            var reservation = await db.Reservations.FindAsync(reservationId);
            if (reservation != null) {
                var rental = new Rental
                {
                    CarId = reservation.CarId,
                    CustomerId = reservation.CustomerId,
                    EndDate = reservation.EndDate,
                    RentalFee = reservation.ReservationFee,
                    StartDate = reservation.StartDate,
                    Status = Constants.RENTAL_STATUS_RENTED,
                    ReservationId = reservationId,
                    PickupLocationId=reservation.PickupLocationId
                };
                reservation.Status = Constants.RESERVATION_STATUS_RENTED;
                await db.Rentals.AddAsync(rental);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateRental(Rental rental)
        {
            await db.Rentals.AddAsync(rental);
            await db.SaveChangesAsync();
        }

        public IEnumerable<Rental> GetAll()
        {
            return db.Rentals
                    .Include(r => r.Car)
                    .ThenInclude(r => r.CarType)
                    .Include(r => r.Car)
                    .ThenInclude(r => r.CarImages)
                    .Include(r => r.Customer)
                    .ThenInclude(r => r.Address)
                    .Include(r => r.Reservation)
                    .Include(r=>r.PickupLocation)
                    .AsEnumerable();
        }

        public async Task<Rental?> GetById(int rentalId) {
            return await db.Rentals
                    .Include(r => r.Car)
                    .ThenInclude(r => r.CarType)
                    .Include(r => r.Car)
                    .ThenInclude(r => r.CarImages)
                    .Include(r => r.Customer)
                    .ThenInclude(r => r.Address)
                    .Include(r => r.Reservation).FirstOrDefaultAsync(r => r.Id == rentalId);
        }
    }
}

