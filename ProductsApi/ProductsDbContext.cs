using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;

namespace CustomersApi
{
  public class ProductsDbContext : DbContext
  {
    public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
  }

}
