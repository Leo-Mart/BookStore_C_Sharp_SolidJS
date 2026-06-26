using BookStore.DbContexts;
using BookStore.Interfaces;
using BookStore.Mappers;
using BookStore.Models.OrderItems;

namespace BookStore.Repository
{
  public class OrderItemRepository(ApplicationDbContext context) : IOrderItemRepository
  {
    private readonly ApplicationDbContext _context = context;    

    public async Task<OrderItemDto> CreateOrderItemAsync(OrderItem item)
    {
      item.CreatedAt = DateTime.UtcNow;
      await _context.OrderItems.AddAsync(item);
      await _context.SaveChangesAsync();
      return item.ToOrderItemDtoFromOrderItem();
    }

    public async Task<OrderItemDto> GetOrderItemByIdAsync(int orderItemId)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<OrderItemDto>> GetOrderItemsAsync(int orderId)
    {
      throw new NotImplementedException();
    }
  }
}