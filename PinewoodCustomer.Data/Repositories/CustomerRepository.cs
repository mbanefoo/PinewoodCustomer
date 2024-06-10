using Microsoft.EntityFrameworkCore;
using PinewoodCustomer.Shared.Models;

namespace PinewoodCustomer.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly PinewoodDbContext _context;
        public CustomerRepository(PinewoodDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();// creates database if it doesn't exist
        }

        public async Task<List<Customer>> GetCustomerListAsync()
        {
            return await _context.customers.ToListAsync<Customer>();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _context.customers.FirstOrDefaultAsync(cust => cust.id == id);
        }

        public async Task<Customer> SaveCustomerAsync(Customer customer)
        {
            var addedEntity = await _context.customers.AddAsync(customer);
            _context.SaveChanges();
            return addedEntity.Entity;
        }

        public async Task<Customer?> UpdateCustomerAsync(Customer customer)
        {
            var foundCustomer =await _context.customers.FirstOrDefaultAsync(cust => cust.id == customer.id);

            if (foundCustomer != null)
            {
                foundCustomer.firstName = customer.firstName;
                foundCustomer.lastName = customer.lastName;
                foundCustomer.gender = customer.gender;
                foundCustomer.email = customer.email;
                foundCustomer.phone = customer.phone;
                foundCustomer.address = customer.address;
                foundCustomer.city = customer.city;
                foundCustomer.county =customer.county;
                foundCustomer.country = customer.country;
                foundCustomer.postCode=customer.postCode;
                await _context.SaveChangesAsync();
                return foundCustomer;
            }
            return null;
        }

        public async Task DeleteCustomerByIdAsync(int id)
        {
            var foundCustomer = await _context.customers.FirstOrDefaultAsync(cust => cust.id == id);
            if (foundCustomer == null) return;
            _context.customers.Remove(foundCustomer);
            _context.SaveChanges();
        }
    }
}
