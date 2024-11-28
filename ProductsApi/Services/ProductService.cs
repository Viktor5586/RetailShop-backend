using ProductsApi.Models;
using ProductsApi.Repositories;

namespace ProductsApi.Services
{
  public class ProductService : IProductService
  {
    private readonly IProductsRepository _productsRepository;

    public ProductService(IProductsRepository productsRepository)
    {
      _productsRepository = productsRepository;
    }

    public async Task CreateProductAsync(Product product)
    {
      product.CreatedAt = DateTime.Now;
      product.UpdatedAt = DateTime.Now;
      await _productsRepository.CreateProductAsync(product).ConfigureAwait(false);
    }

    public async Task DeleteProductAsync(long productId)
    {
      Product product = await _productsRepository.GetProductByIdAsync(productId).ConfigureAwait(false);
      if (product != null)
      {
        await _productsRepository.DeleteProductAsync(product).ConfigureAwait(false);
      }
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
      return await _productsRepository.GetAllProductsAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync(List<long> productIds)
    {
      return await _productsRepository.GetAllProductsAsync(productIds).ConfigureAwait(false);
    }

    public async Task<Product> GetProductByIdAsync(long productId)
    {
      return await _productsRepository.GetProductByIdAsync(productId).ConfigureAwait(false);
    }

    public async Task UpdateProductAsync(Product product)
    {
      product.UpdatedAt = DateTime.Now;
      await _productsRepository.UpdateProductAsync(product).ConfigureAwait(false);
    }
  }
}
