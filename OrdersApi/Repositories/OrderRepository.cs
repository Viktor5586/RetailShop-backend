using CustomersApi;
using Microsoft.EntityFrameworkCore;
using OrdersApi.Models;

namespace OrdersApi.Repositories
{
  public class OrderRepository : IOrderRepository
  {
    private readonly OrderDbContext _context;

    public OrderRepository(OrderDbContext context)
    {
      _context = context;
    }

    public async Task AddOrderAsync(Order order)
    {
      await _context.Orders.AddAsync(order).ConfigureAwait(false);
      await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task DeleteOrderAsync(Order order)
    {
      _context.Orders.Remove(order);
      await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
      return await _context.Orders.Include(o => o.OrderItems).ToListAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(long customerId)
    {
      return await _context.Orders.Include(o => o.OrderItems)
                 .Where(o => o.CustomerId == customerId)
                 .ToListAsync()
                 .ConfigureAwait(false);
    }

    public async Task<Order> GetOrderByIdAsync(long orderId)
    {
      return await _context.Orders.Include(o => o.OrderItems)
                  .FirstOrDefaultAsync(o => o.OrderId == orderId).ConfigureAwait(false);
    }

    public async Task UpdateOrderAsync(Order order)
    {
      _context.Orders.Update(order);
      await _context.SaveChangesAsync().ConfigureAwait(false);
    }
  }
}
