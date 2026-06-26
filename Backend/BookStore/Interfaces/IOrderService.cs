using BookStore.Models.Orders;

namespace BookStore.Interfaces
{
    public interface IOrderService
    {
        Task<Order?> CreateNewOrderForUser(CreateOrderDto order, string userId);
        Task<Order?> CreateNewOrderForGuest(CreateOrderDto order);
    }
}