using System;
using CarRentalSystem.Models;

namespace CarRentalSystem.Services
{
	public interface IRentalService
	{
        Task CreateRentalFromReservation(int reservationId);
        Task CreateRental(Rental rental);
        IEnumerable<Rental> GetAll();
        Task<Rental?> GetById(int rentalId);
    }
}

