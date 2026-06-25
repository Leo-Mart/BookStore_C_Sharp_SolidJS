using BookStore.Models.Orders;

namespace BookStore.Interfaces
{
    public interface IOrderService
    {
        Task<Order?> CreateNewOrder(CreateOrderDto newOrder, string userId);
    }
}