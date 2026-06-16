using BookStore.Interfaces;
using BookStore.Mappers;
using BookStore.Models.Orders;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController(ILogger<OrdersController> logger, IOrderRepository orderRepo, IInventoryRepository inventoryRepo) : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly IOrderRepository _orderRepo = orderRepo;
        private IInventoryRepository _inventoryRepo = inventoryRepo;
        
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
            // TODO: should probably calculate the price in this step as well?
            var orderToSave = order.ToOrderFromCreateDto();
            var savedOrder = await _orderRepo.CreateOrderAsync(orderToSave);
            
            return CreatedAtAction("GetOrder",
            new
            {
                orderId = savedOrder.Id
            }, savedOrder.ToDtoFromOrder());
        }
    }
}