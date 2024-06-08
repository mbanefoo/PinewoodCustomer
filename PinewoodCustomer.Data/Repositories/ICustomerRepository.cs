using PinewoodCustomer.Shared.Models;

namespace PinewoodCustomer.Data.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomerListAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<Customer> SaveCustomerAsync(Customer customer);
        Task<Customer?> UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerByIdAsync(int id);
    }
}
