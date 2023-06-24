using System;
using CarRentalSystem.Models;

namespace CarRentalSystem.Services
{
	public interface ICustomerService
	{
		Task<IEnumerable<Customer>> GetAll();
        Task<Customer?> GetById(int customerId);
        Task Create(Customer customer);
        Task Delete(int customerId);
        Task Update(Customer customer);
    }
}

