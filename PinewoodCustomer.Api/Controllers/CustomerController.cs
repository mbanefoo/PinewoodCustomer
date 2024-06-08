using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PinewoodCustomer.Data.Repositories;
using PinewoodCustomer.Shared.Models;

namespace PinewoodCustomer.Api.Controllers
{
    [Route("api/v1/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetCustomerList()
        {
            var customerList = await _customerRepository.GetCustomerListAsync();
            return Ok(customerList);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCustomer([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCustomer = await _customerRepository.SaveCustomerAsync(customer);

            return Created("Customer", createdCustomer);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            if (customer == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerToUpdate =await _customerRepository.GetCustomerByIdAsync(customer.id);

            if (customerToUpdate == null)
                return NotFound();

           await _customerRepository.UpdateCustomerAsync(customer);

            return NoContent(); //success
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (id == 0)
                return BadRequest();

            var customerToDelete =await _customerRepository.GetCustomerByIdAsync(id);
            if (customerToDelete == null)
                return NotFound();

            await _customerRepository.DeleteCustomerByIdAsync(id);

            return NoContent();//success
        }
    }
}
