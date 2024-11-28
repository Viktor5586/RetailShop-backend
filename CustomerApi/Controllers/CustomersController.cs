using CustomersApi.Models;
using CustomersApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomersApi.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class CustomersController : ControllerBase
  {
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
      _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
      var customers = await _customerService.GetAllCustomersAsync();
      return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(long id)
    {
      var customer = await _customerService.GetCustomerByIdAsync(id);
      if (customer == null)
        return NotFound();

      return Ok(customer);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
    {
      await _customerService.AddCustomerAsync(customer);
      return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustomerId }, customer);
    }

    [HttpPut("edit")]
    public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
    {
      if (customer == null || customer.CustomerId <= 0)
      {
        return BadRequest("Invalid customer data.");
      }

      var existingCustomer = await _customerService.GetCustomerByIdAsync(customer.CustomerId);
      if (existingCustomer == null)
      {
        return NotFound("Customer not found.");
      }
      else
      {
        existingCustomer.FirstName = customer.FirstName;
        existingCustomer.LastName = customer.LastName;
        existingCustomer.Email = customer.Email;
        existingCustomer.PhoneNumber = customer.PhoneNumber;
        await _customerService.UpdateCustomerAsync(existingCustomer);
        return CreatedAtAction(nameof(GetCustomerById), new { id = existingCustomer.CustomerId }, existingCustomer);
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(long id)
    {
      await _customerService.DeleteCustomerAsync(id);
      return NoContent();
    }
  }
}
