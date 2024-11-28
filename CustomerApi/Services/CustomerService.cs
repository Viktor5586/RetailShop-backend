
using CustomersApi.Models;
using CustomersApi.Repositories;

namespace CustomersApi.Services
{
  public class CustomerService : ICustomerService
  {
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
      _customerRepository = customerRepository;
    }

    public async Task AddCustomerAsync(Customer customer)
    {
      customer.CreatedAt = DateTime.Now;
      customer.UpdatedAt = DateTime.Now;
      await _customerRepository.AddCustomerAsync(customer).ConfigureAwait(false);
    }

    public async Task DeleteCustomerAsync(long customerId)
    {
      Customer customerDto = await _customerRepository.GetCustomerByIdAsync(customerId).ConfigureAwait(false);
      if (customerDto != null)
      {
        await _customerRepository.DeleteCustomerAsync(customerDto).ConfigureAwait(false);
      }
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
      return await _customerRepository.GetAllCustomersAsync().ConfigureAwait(false);
    }

    public async Task<Customer> GetCustomerByIdAsync(long customerId)
    {
      return await _customerRepository.GetCustomerByIdAsync(customerId).ConfigureAwait(false);
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
      customer.UpdatedAt = DateTime.Now;
      await _customerRepository.UpdateCustomerAsync(customer).ConfigureAwait(false);  
    }
  }
}
