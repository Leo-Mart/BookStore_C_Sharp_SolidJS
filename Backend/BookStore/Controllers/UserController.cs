using BookStore.Extensions;
using BookStore.Interfaces;
using BookStore.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/user")]
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
        
    }
}