using BookStore.Interfaces;
using BookStore.Mappers;
using BookStore.Models.Orders;
using BookStore.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Services
{
    public class OrderService(IOrderRepository orderRepo, IPaymentMethodRepository paymentMethodRepo, IPaymentRepository paymentRepo, UserManager<AppUser> userManager) : IOrderService
    {
        private readonly IOrderRepository _orderRepo = orderRepo;
        private readonly IPaymentMethodRepository _paymentMethodRepo = paymentMethodRepo;
        private readonly IPaymentRepository _paymentRepo = paymentRepo;
        private readonly UserManager<AppUser> _userManager = userManager;

        public async Task<Order?> CreateNewOrder(CreateOrderDto newOrder, string userId)
        {
            
            var orderToSave = newOrder.ToOrderFromCreateDto();            
            orderToSave.AppUserId = userId;
            var savedOrder = await _orderRepo.CreateOrderAsync(orderToSave);

            return savedOrder;
        }
    }
}