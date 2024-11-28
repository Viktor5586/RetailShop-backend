using CustomersApi;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
  public class ProductsRepository : IProductsRepository
  {
    private readonly ProductsDbContext _productsDbContext;
    public ProductsRepository(ProductsDbContext productsDbContext)
    {
      _productsDbContext = productsDbContext;
    }

    public async Task CreateProductAsync(Product product)
    {
      await _productsDbContext.AddAsync(product).ConfigureAwait(false);
      await _productsDbContext.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task DeleteProductAsync(Product product)
    {
      _productsDbContext.Products.Remove(product);
      await _productsDbContext.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync(List<long> productIds)
    {
      return await _productsDbContext.Products.Where(p => productIds.Contains(p.ProductId)).ToListAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
      return await _productsDbContext.Products.ToListAsync().ConfigureAwait(false);
    }

    public async Task<Product> GetProductByIdAsync(long productId)
    {
      return await _productsDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId).ConfigureAwait(false);
    }

    public async Task UpdateProductAsync(Product product)
    {
      _productsDbContext.Products.Update(product);
      await _productsDbContext.SaveChangesAsync().ConfigureAwait(false);
    }
  }
}
