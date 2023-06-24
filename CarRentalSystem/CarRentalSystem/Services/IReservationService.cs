using System;
using CarRentalSystem.Models;

namespace CarRentalSystem.Services
{
	public interface IReservationService
	{
        IEnumerable<PickupLocation> GetPickupLocations();
        Task<string> CreateReservation(Reservation reservation);
        Task<IEnumerable<Reservation>> getAll();
        Task<Reservation?> GetById(int reservationId);
        Task Cancel(int reservationId);
        Task UpdateReservation(Reservation reservation);
    }
}

