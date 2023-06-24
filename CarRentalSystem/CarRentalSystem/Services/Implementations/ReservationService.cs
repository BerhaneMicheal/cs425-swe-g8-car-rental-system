using System;
using CarRentalSystem.Data;
using CarRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Services.Implementations
{
	public class ReservationService:IReservationService
	{
        private readonly AppDbContext db;
        private readonly IAuthService authService;

        public ReservationService(AppDbContext db, IAuthService authService)
		{
            this.db = db;
            this.authService = authService;
        }

		public IEnumerable<PickupLocation> GetPickupLocations() {
			return db.PickupLocations.ToList();
		}

		public async Task<string> CreateReservation(Reservation reservation) {
			var code = (new Random()).Next(9999, 9999999).ToString().PadLeft(7, '0');
			var customerId = authService.GetLoginData()!.Id;
			reservation.Code = code;
			reservation.CustomerId = customerId;
			reservation.Status = Constants.RESERVATION_STATUS_PENDING;
			await db.Reservations.AddAsync(reservation);
			await db.SaveChangesAsync();

			return code;
		}

		public async Task<IEnumerable<Reservation>> getAll() {
			return await Task.FromResult(db.Reservations
				.Include(r=>r.Car)
				.ThenInclude(c=>c.CarType)
				.Include(r=>r.Car)
				.ThenInclude(c=>c.CarImages)
				.Include(c=>c.Customer)
				.ThenInclude(c=>c.Address)
				.Include(r=>r.PickupLocation)
				.AsEnumerable());
		}

		public async Task<Reservation?> GetById(int reservationId) {
			return await db.Reservations
				.Include(r => r.Car)
				.ThenInclude(c => c.CarType)
				.Include(r => r.Car)
				.ThenInclude(c => c.CarImages)
				.Include(c => c.Customer)
				.ThenInclude(c => c.Address)
				.Include(r => r.PickupLocation)
				.FirstOrDefaultAsync(r => r.Id == reservationId);

        }

		public async Task Cancel(int reservationId) {
			var reservation = await GetById(reservationId);
			if (reservation != null) {
				reservation.Status = Constants.RESERVATION_STATUS_CANCELLED;
				await db.SaveChangesAsync();
			}
		}

        public async Task UpdateReservation(Reservation reservation)
        {
			var _reservation = await db.Reservations.FindAsync(reservation.Id);
			if (_reservation != null) {
				_reservation.Status = reservation.Status;
				_reservation.PickupLocationId = reservation.PickupLocationId;
				_reservation.StartDate = reservation.StartDate;
				_reservation.EndDate = reservation.EndDate;
				_reservation.ReservationFee = reservation.ReservationFee;

				await db.SaveChangesAsync();
			}
        }
    }
}

