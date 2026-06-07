using BookStore.Interfaces;
using BookStore.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/users")]
    public class UserController(IUserRepository userRepo) : ControllerBase
    {
        private readonly IUserRepository _userRepo = userRepo;

    [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var foundUser = await _userRepo.GetUserByIdAsync(userId);

            if (foundUser == null)
            {
                return NotFound();
            }

            return Ok(foundUser.ToResponseUserDtoFromUser());
        }

        
    }
}