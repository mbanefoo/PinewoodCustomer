using PinewoodCustomer.Shared.Models;
using PinewoodCustomer.UI.Interface;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace PinewoodCustomer.UI.Services
{
    public class CustomerDataService : ICustomerDataService, IPinewoodAPI
    {
        private readonly HttpClient _httpClient;

        public Customer SavedCustomer { get; set; }

        public CustomerDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<Customer> AddCustomer(Customer customer)
        {
            var customerJson =
               new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/v1/customer", customerJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Customer>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeleteCustomer(int id)
        {
            await _httpClient.DeleteAsync($"api/v1/customer/{id}");
        }

        public async Task<IEnumerable<Customer>?> GetAllCustomers()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Customer>>
     (await _httpClient.GetStreamAsync($"api/v1/customer"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Customer?> GetCustomerDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<Customer>
                (await _httpClient.GetStreamAsync($"api/v1/customer/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateCustomer(Customer customer)
        {
            var customerJson = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync("api/v1/customer", customerJson);
        }
    }
}
