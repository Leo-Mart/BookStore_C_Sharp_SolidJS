using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using someboeoeks.Interfaces;
using someboeoeks.Mappers;

namespace someboeoeks.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

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