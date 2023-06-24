using System;
using CarRentalSystem.Data;
using CarRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Services.Implementations
{
	public class CustomerService:ICustomerService
	{
        private readonly AppDbContext db;

        public CustomerService(AppDbContext db)
		{
            this.db = db;
        }

        public async Task Create(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.Password)) {
                customer.Password = "12345";
            }
            await db.Customers.AddAsync(customer);
            await db.SaveChangesAsync();
            // send email to customer
        }

        public async Task Delete(int customerId)
        {
            var customer = await db.Customers.FindAsync(customerId);
            if (customer != null)
            {
                db.Customers.Remove(customer);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await Task.FromResult(db.Customers.Include(c=>c.Address));
        }

        public async Task<Customer?> GetById(int customerId)
        {
            return await db.Customers.Include(c=>c.Address).FirstOrDefaultAsync(c=> c.Id==customerId);
        }

        public async Task Update(Customer customer)
        {
            var _customer = await GetById(customer.Id);
            if (_customer != null)
            {
                _customer.Address.City = customer.Address.City;
                _customer.Address.State = customer.Address.State;
                _customer.Address.Street = customer.Address.Street;
                _customer.Address.ZipCode = customer.Address.ZipCode;

                _customer.DriverLicenceNumber = customer.DriverLicenceNumber;
                _customer.Email = customer.Email;
                _customer.FirstName = customer.FirstName;
                _customer.LastName = customer.LastName;
                _customer.Phone = customer.Phone;

                await db.SaveChangesAsync();
            }
        }
    }
}

