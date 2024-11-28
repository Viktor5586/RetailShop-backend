using OrdersApi.Models;
using OrdersApi.Repositories;

namespace OrdersApi.Services
{
  public class OrderService : IOrderService
  {
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
      _orderRepository = orderRepository;
    }

    public async Task AddOrderAsync(Order order)
    {
      await _orderRepository.AddOrderAsync(order).ConfigureAwait(false);
    }

    public async Task DeleteOrderAsync(long orderId)
    {
      Order order = await _orderRepository.GetOrderByIdAsync(orderId).ConfigureAwait(false);
      if (order != null)
      {
        await _orderRepository.DeleteOrderAsync(order).ConfigureAwait(false);
      }
    }

    public async Task DeleteOrdersForCustomerAsync(long customerId)
    {
      IEnumerable<Order> orders = await _orderRepository.GetOrdersByCustomerIdAsync(customerId).ConfigureAwait(false);
      foreach (var order in orders)
      {
        await _orderRepository.DeleteOrderAsync(order).ConfigureAwait(false);
      }
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
      return await _orderRepository.GetAllOrdersAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(long customerId)
    {
      return await _orderRepository.GetOrdersByCustomerIdAsync(customerId).ConfigureAwait(false);
    }

    public async Task<decimal> GetTotalSalesForCustomerAsync(long customerId)
    {
      IEnumerable<Order> orders = await _orderRepository.GetOrdersByCustomerIdAsync(customerId).ConfigureAwait(false);
      decimal totalSales = orders.SelectMany(order => order.OrderItems).Sum(orderItem => orderItem.LineTotal);
      return totalSales;
    }

    public async Task<Order> GetOrderByIdAsync(long orderId)
    {
      return await _orderRepository.GetOrderByIdAsync(orderId).ConfigureAwait(false);
    }

    public async Task UpdateOrderAsync(Order order)
    {
      await _orderRepository.UpdateOrderAsync(order).ConfigureAwait(false);
    }
  }
}
