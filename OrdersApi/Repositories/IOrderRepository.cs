using OrdersApi.Models;

namespace OrdersApi.Repositories
{
  public interface IOrderRepository
  {
    public Task<IEnumerable<Order>> GetAllOrdersAsync();
    public Task<Order> GetOrderByIdAsync(long orderId);
    public Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(long customerId);
    public Task AddOrderAsync(Order order);
    public Task UpdateOrderAsync(Order order);
    public Task DeleteOrderAsync(Order order);
  }
}
