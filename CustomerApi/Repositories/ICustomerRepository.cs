using CustomersApi.Models;

namespace CustomersApi.Repositories
{
  public interface ICustomerRepository
  {
    public Task<IEnumerable<Customer>> GetAllCustomersAsync();
    public Task<Customer> GetCustomerByIdAsync(long customerId);
    public Task AddCustomerAsync(Customer customer);
    public Task UpdateCustomerAsync(Customer customer);
    public Task DeleteCustomerAsync(Customer customer);
  }
}
