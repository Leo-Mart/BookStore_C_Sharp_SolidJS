using BookStore.Extensions;
using BookStore.Interfaces;
using BookStore.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/user/")]
    [Authorize]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet]
        public async Task<ActionResult<CustomerDto>?> GetLoggedInUserInfo()
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var customerInfo = await _userService.GetCustomerInfo(userId);

            if (customerInfo == null)
            {
                return BadRequest(); // TODO: update to custom error?
            }

            return customerInfo;
        }

        [HttpGet("orders")]
        public async Task<ActionResult<CustomerDto?>> GetUsersOrders()
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var customerOrders = await _userService.GetCustomerOrders(userId);

            if (customerOrders == null)
            {
                return NotFound();
            }

            return customerOrders;
        }

        [HttpGet("addresses")]
        public async Task<ActionResult<CustomerDto?>> GetUsersAddresses()
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var customerAddresses = await _userService.GetCustomerAddresses(userId);

            if (customerAddresses == null)
            {
                return NotFound();
            }

            return customerAddresses;
        }

        [HttpGet("wishlists")]
        public async Task<ActionResult<CustomerDto?>> GetUsersWishlists()
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var customerWishlists = await _userService.GetCustomerWishlists(userId);

            if (customerWishlists == null)
            {
                return NotFound();
            }

            return customerWishlists;
        }
    }
}
