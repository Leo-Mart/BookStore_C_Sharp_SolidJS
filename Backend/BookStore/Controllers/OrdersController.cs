using BookStore.Extensions;
using BookStore.Interfaces;
using BookStore.Mappers;
using BookStore.Models.Orders;
using BookStore.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController(ILogger<OrdersController> logger, IOrderRepository orderRepo, IInventoryRepository inventoryRepo, UserManager<AppUser> userManager) : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly IOrderRepository _orderRepo = orderRepo;
        private readonly IInventoryRepository _inventoryRepo = inventoryRepo;
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
        [Authorize]
        public async Task<ActionResult<OrderDto>> CreateNewOrder(CreateOrderDto order)
        {  
            if (order.Items.Count == 0)
            {
                return BadRequest("No Items in cart");
            }
            var userId = User.GetUserId();
            if (userId == null)
            {
                return NotFound();
            }
            
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            // TODO: should probably calculate the price in this step as well?
            // maybe also check all items against the db so prices match etc.
            var orderToSave = order.ToOrderFromCreateDto();
            orderToSave.AppUserId = user.Id;
            var savedOrder = await _orderRepo.CreateOrderAsync(orderToSave);
            
            return CreatedAtAction("GetOrder",
            new
            {
                orderId = savedOrder.Id
            }, savedOrder.ToDtoFromOrder());
        }
    }
}