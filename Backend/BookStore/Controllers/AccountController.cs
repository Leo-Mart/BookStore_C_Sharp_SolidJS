using BookStore.Extensions;
using BookStore.Interfaces;
using BookStore.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController(IAccountService accountService) : ControllerBase
    {
        private readonly IAccountService _accountService = accountService;

        [HttpGet("me")]
        public async Task<ActionResult<AuthResponse>> GetMe()
        {
            var userId = User.GetUserId();
            if (userId == null)
                return Unauthorized();

            var response = await _accountService.GetMe(userId);
            return response;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userInfo = await _accountService.LoginUser(loginDto);

            return Ok(userInfo);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            await _accountService.RefreshAccessToken();

            return Ok();
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailDto confirmDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _accountService.ConfirmUserEmail(confirmDto.Email, confirmDto.Token);

            return NoContent();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutUser();
            return Ok("Logout successful");
        }

        [HttpPost("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePWDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.GetUserId();
            if (userId == null)
                return Unauthorized();

            await _accountService.ChangeUserPassword(
                userId,
                changePWDto.OldPassword,
                changePWDto.NewPassword
            );

            return NoContent();
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgottenPassword(
            [FromBody] ForgottenPasswordDto forgottenPWDto
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _accountService.GeneratePasswordResetTokenForUser(forgottenPWDto.Email);
            return NoContent();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPWDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _accountService.ResetUserPassword(
                resetPWDto.Email,
                resetPWDto.Token,
                resetPWDto.NewPassword
            );
            return NoContent();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _accountService.RegisterNewUser(registerDto);

            return Ok();
        }
    }
}
