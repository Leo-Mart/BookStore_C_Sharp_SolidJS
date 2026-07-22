using BookStore.DbContexts;
using BookStore.Interfaces;
using BookStore.Models.Users;
using BookStore.Models.Wishlists;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController(
        UserManager<AppUser> userManager,
        ITokenService tokenService,
        SignInManager<AppUser> signInManager,
        ApplicationDbContext context
    ) : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly ITokenService _tokenService = tokenService;
        private readonly SignInManager<AppUser> _signIngManager = signInManager;
        private readonly ApplicationDbContext _context = context;

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x =>
                x.UserName == loginDto.Email.ToLower()
            );

            if (user == null)
                return Unauthorized(
                    new ErrorResponse { Message = "Username not found and/or password incorrect." }
                );

            var result = await _signIngManager.CheckPasswordSignInAsync(
                user,
                loginDto.Password,
                false
            );

            if (!result.Succeeded)
                return Unauthorized(
                    new ErrorResponse { Message = "Username not found and/or password incorrect." }
                );

            return Ok(
                new NewUserDto { Email = user.Email, Token = _tokenService.CreateToken(user) }
            );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var appUser = new AppUser
                {
                    UserName = registerDto.Email,
                    Email = registerDto.Email,
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        // Probably find a better spot for this somewhere, but should work for now
                        await _context.Wishlists.AddAsync(
                            new Wishlist
                            {
                                AppUserId = appUser.Id,
                                Description = "This is the default wishlist",
                            }
                        );

                        await _context.SaveChangesAsync();

                        return Ok(
                            new NewUserDto
                            {
                                Email = appUser.Email,
                                Token = _tokenService.CreateToken(appUser),
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
