using Microsoft.AspNetCore.Mvc;
using OrdersApi.Models;
using OrdersApi.Services;

namespace OrdersApi.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class OrdersController : ControllerBase
  {
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
      _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
      var orders = await _orderService.GetAllOrdersAsync();
      return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(long id)
    {
      var order = await _orderService.GetOrderByIdAsync(id);
      if (order == null)
        return NotFound();

      return Ok(order);
    }
    
    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetOrderByCustomerId(long customerId)
    {
      var order = await _orderService.GetOrdersByCustomerIdAsync(customerId);
      if (order == null)
        return NotFound();

      return Ok(order);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddOrder([FromBody] Order order)
    {
      await _orderService.AddOrderAsync(order);
      return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder(long id, [FromBody] Order order)
    {
      if (id != order.OrderId)
        return BadRequest();

      await _orderService.UpdateOrderAsync(order);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(long id)
    {
      await _orderService.DeleteOrderAsync(id);
      return NoContent();
    }
    
    [HttpDelete("customer/{id}")]
    public async Task<IActionResult> DeleteOrderForCustomer(long id)
    {
      await _orderService.DeleteOrdersForCustomerAsync(id);
      return NoContent();
    }
  }
}
