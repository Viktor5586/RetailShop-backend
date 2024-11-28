using OrdersApi.Models;

namespace OrdersApi.Services
{
  public interface IOrderService
  {
    public Task<IEnumerable<Order>> GetAllOrdersAsync();
    public Task<Order> GetOrderByIdAsync(long orderId);
    public Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(long customerId); 
    public Task<decimal> GetTotalSalesForCustomerAsync(long customerId);
    public Task AddOrderAsync(Order order);
    public Task UpdateOrderAsync(Order order);
    public Task DeleteOrderAsync(long orderId);
    public Task DeleteOrdersForCustomerAsync(long customerId);
  }
}
