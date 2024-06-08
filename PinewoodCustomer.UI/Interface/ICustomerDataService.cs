using PinewoodCustomer.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PinewoodCustomer.UI.Interface
{
    public interface ICustomerDataService
    {
        Customer SavedCustomer { get; set; }
        Task<IEnumerable<Customer>?> GetAllCustomers();
        Task<Customer?> GetCustomerDetails(int customerId);
        Task<Customer> AddCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(int customerId);
    }
}
