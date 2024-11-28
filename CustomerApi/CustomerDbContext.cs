using CustomersApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomersApi
{
  public class CustomerDbContext : DbContext
  {
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }
  }

}
