using BookStore.DbContexts;
using BookStore.Interfaces;
using BookStore.Mappers;
using BookStore.Models.Books;
using BookStore.Models.OrderItems;
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

    public async Task<ICollection<OrderInfoDto>?> GetOrdersForUserAsync(string userId)
    {
      return await _context.Orders
      .Where(o => o.AppUserId == userId)
      .Select(o => new OrderInfoDto
      {
        OrderStatus = o.OrderStatus,
        OrderTotalCost = o.OrderTotalCost,
        ShippingMethod = o.ShippingMethod,
        Items = (ICollection<OrderItemInfoDto>)o.Items.Select(oi => new OrderItemInfoDto
        {
          UnitPrice = oi.UnitPrice,
          Quantity = oi.Quantity,
          BookInfo = new BookItemInfoDto
          {
            Isbn = oi.Book.Isbn,
            Title = oi.Book.Title,
            PublishedDate = oi.Book.PublishedDate,
            Description = oi.Book.Description,
            Price = oi.Book.Price,
            CoverImageUrl = oi.Book.CoverImageUrl,
            Authors = oi.Book.Authors.Select(a => a.ToAuthorDto()).ToList()
          }
        })
      }).ToListAsync();
    }

    public async Task<bool> OrderExistsAsync(int orderId)
    {
      return await _context.Orders.AnyAsync(o => o.Id == orderId);
    }
  }
}