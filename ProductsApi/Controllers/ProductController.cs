using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;
using ProductsApi.Services;

namespace ProductsApi.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class ProductController : ControllerBase
  {
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
      _productService = productService;
    }

    [HttpGet("productsFromOrder")]
    public async Task<IActionResult> GetProducts([FromQuery] List<long> productIds)
    {
      var products = await _productService.GetAllProductsAsync(productIds);
      return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
      Product product = await _productService.GetProductByIdAsync(id);
      if (product == null)
      {
        return NotFound();
      }

      return Ok(product);
    }

    [HttpPost("add")]
    public async Task<IActionResult> CreateProduct([FromBody] Product product)
    {
      if (product == null)
      {
        return BadRequest("Product data is required.");
      }

      await _productService.CreateProductAsync(product);
      return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
    {
      if (id != product.ProductId)
      {
        return BadRequest("Product ID mismatch.");
      }
      await _productService.UpdateProductAsync(product);

      return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
      await _productService.DeleteProductAsync(id);
      return NoContent();
    }
  }
}
