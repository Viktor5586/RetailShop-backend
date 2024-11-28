using CustomersApi.Models;

namespace CustomersApi.Services
{
  public interface ICustomerService
  {
    public Task<IEnumerable<Customer>> GetAllCustomersAsync();
    public Task<Customer> GetCustomerByIdAsync(long customerId);
    public Task AddCustomerAsync(Customer customer);
    public Task UpdateCustomerAsync(Customer customer);
    public Task DeleteCustomerAsync(long customerId);
  }
}
