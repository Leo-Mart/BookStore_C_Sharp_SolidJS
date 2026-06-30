using BookStore.Interfaces;
using BookStore.Models.ShippingMethods;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/shipping-methods")]
    public class ShippingMethodsController(ILogger<ShippingMethodsController> logger, IShippingMethodRepository shippingMethodRepo) : ControllerBase
    {

        private readonly ILogger<ShippingMethodsController> _logger = logger;
        private readonly IShippingMethodRepository _smRepo = shippingMethodRepo;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShippingMethod>>> GetShippingMethods()
        {
            var shippingMethods = await _smRepo.GetShippingMethodsAsync();
            return Ok(shippingMethods);
        }
        
    }
}