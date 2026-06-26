using BookStore.DbContexts;
using BookStore.Interfaces;
using BookStore.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
  public class OrderRepository(ApplicationDbContext context) : IOrderRepository
  {
    private readonly ApplicationDbContext _context = context;
    public async Task<Order> CreateOrderAsync(Order order)
    {
      order.CreatedAt = DateTime.UtcNow;
      order.UpdatedAt = DateTime.UtcNow;
      await _context.Orders.AddAsync(order);
      foreach (var orderItem in order.Items)
      {
        orderItem.OrderId = order.Id;
        await _context.OrderItems.AddAsync(orderItem);
      }
      await _context.SaveChangesAsync();
      return order;
    }

    public async Task<Order> GetOrderByIdAsync(int orderId)
    {
      return await _context.Orders.Where(o => o.Id == orderId).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersForUserAsync(string userId)
    {
      throw new NotImplementedException();
    }

    public async Task<bool> OrderExistsAsync(int orderId)
    {
      return await _context.Orders.AnyAsync(o => o.Id == orderId);
    }
  }
}