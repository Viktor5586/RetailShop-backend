using CustomersApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomersApi.Repositories
{
  public class CustomerRepository : ICustomerRepository
  {
    private readonly CustomerDbContext _context;

    public CustomerRepository(CustomerDbContext context)
    {
      _context = context;
    }

    public async Task AddCustomerAsync(Customer customer)
    {
      await _context.Customers.AddAsync(customer).ConfigureAwait(false);
      await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task DeleteCustomerAsync(Customer customer)
    {
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
      return await _context.Customers.ToListAsync().ConfigureAwait(false);
    }

    public async Task<Customer> GetCustomerByIdAsync(long customerId)
    {
      return await _context.Customers.FindAsync(customerId).ConfigureAwait(false);
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
      _context.Customers.Update(customer);
      await _context.SaveChangesAsync().ConfigureAwait(false);
    }
  }
}
