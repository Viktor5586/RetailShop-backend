using ProductsApi.Models;

namespace ProductsApi.Services
{
  public interface IProductService
  {
    public Task<IEnumerable<Product>> GetAllProductsAsync();
    public Task<IEnumerable<Product>> GetAllProductsAsync(List<long> productIds);
    public Task<Product> GetProductByIdAsync(long productId);
    public Task CreateProductAsync(Product product);
    public Task UpdateProductAsync(Product product);
    public Task DeleteProductAsync(long productId);
  }
}
