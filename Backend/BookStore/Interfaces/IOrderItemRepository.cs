using BookStore.Models.OrderItems;

namespace BookStore.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<OrderItemDto> CreateOrderItemAsync(OrderItem item);
        Task<OrderItemDto> GetOrderItemByIdAsync(int orderItemId);
        Task<IEnumerable<OrderItemDto>> GetOrderItemsAsync(int orderId);

    }
}