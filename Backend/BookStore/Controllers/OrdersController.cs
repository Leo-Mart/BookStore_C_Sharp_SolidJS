using BookStore.Extensions;
using BookStore.Interfaces;
using BookStore.Mappers;
using BookStore.Models.Orders;
using BookStore.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController(
        ILogger<OrdersController> logger,
        IOrderService orderService,
        IOrderRepository orderRepo,
        UserManager<AppUser> userManager
    ) : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger =
            logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly IOrderService _orderService = orderService;
        private readonly IOrderRepository _orderRepo = orderRepo;
        private readonly UserManager<AppUser> _userManager = userManager;

        [HttpGet("{orderId}", Name = "GetOrder")]
        public async Task<ActionResult<OrderDto>> GetOrder(int orderId)
        {
            if (!await _orderRepo.OrderExistsAsync(orderId))
            {
                _logger.LogInformation($"Order with ID: {orderId} not found.");
                return NotFound();
            }

            var orderFound = await _orderRepo.GetOrderByIdAsync(orderId);

            if (orderFound == null)
            {
                return NotFound();
            }

            return Ok(orderFound.ToDtoFromOrder());
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateNewOrder(CreateOrderDto order)
        {
            if (order.Items.Count == 0)
            {
                return BadRequest("No Items in cart");
            }
            var userId = User.GetUserId();
            if (userId == null)
            {
                var savedOrder = await _orderService.CreateNewOrderForGuest(order);

                return CreatedAtAction(
                    "GetOrder",
                    new { orderId = savedOrder.Id },
                    savedOrder.ToDtoFromOrder()
                );
            }
            else
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return NotFound();
                }

                var savedOrder = await _orderService.CreateNewOrderForUser(order, user.Id);

                return CreatedAtAction(
                    "GetOrder",
                    new { orderId = savedOrder.Id },
                    savedOrder.ToDtoFromOrder()
                );
            }
        }
    }
}

