using BookStore.Models.Orders;

namespace BookStore.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<ICollection<OrderInfoDto>?> GetOrdersForUserAsync(string userId);
        Task<Order> GetOrderByIdAsync(int bookId);
        Task<bool> OrderExistsAsync(int orderId);

    }
}