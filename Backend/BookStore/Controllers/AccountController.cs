using BookStore.DbContexts;
using BookStore.Interfaces;
using BookStore.Models.Users;
using BookStore.Models.Wishlists;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController(
        UserManager<AppUser> userManager,
        ITokenService tokenService,
        IRefreshTokenRepository refreshTokenRepo,
        SignInManager<AppUser> signInManager,
        ApplicationDbContext context
    ) : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly ITokenService _tokenService = tokenService;
        private readonly IRefreshTokenRepository _refreshTokenRepo = refreshTokenRepo;
        private readonly SignInManager<AppUser> _signIngManager = signInManager;
        private readonly ApplicationDbContext _context = context;

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
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

            var refreshToken = _tokenService.CreateRefreshToken();

            var savedRefreshToken = await _refreshTokenRepo.SaveRefreshTokenAsync(
                new RefreshToken { Token = refreshToken, AppUserId = user.Id }
            );

            return Ok(
                new AuthResponse
                {
                    Email = user.Email,
                    AccessToken = _tokenService.CreateJWT(user),
                    RefreshToken = savedRefreshToken.Token,
                    RefreshTokenExpiry = savedRefreshToken.Expires,
                }
            );
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenDto refreshDto)
        {
            var (newRefreshToken, user) = await _tokenService.RefreshTokenAsync(
                refreshDto.RefreshToken
            );
            if (newRefreshToken == null)
            {
                return Unauthorized(new ErrorResponse { Message = "Refresh token not valid." });
            }

            return Ok(
                new AuthResponse
                {
                    Email = user.Email,
                    AccessToken = _tokenService.CreateJWT(user),
                    RefreshToken = newRefreshToken.Token,
                    RefreshTokenExpiry = newRefreshToken.Expires,
                }
            );
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(RefreshTokenDto refreshDto)
        {
            var foundToken = await _refreshTokenRepo.RefreshTokenExistsAsync(
                refreshDto.RefreshToken
            );
            if (foundToken == null || !foundToken.IsActive)
            {
                return NotFound(new ErrorResponse { Message = "Token not found or inactive." });
            }

            await _refreshTokenRepo.RevokeRefreshToken(foundToken);
            return Ok("Token revoked");
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
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        await _context.Wishlists.AddAsync(
                            new Wishlist
                            {
                                AppUserId = appUser.Id,
                                Description = "This is the default wishlist",
                            }
                        );

                        await _context.SaveChangesAsync();

                        var refreshToken = _tokenService.CreateRefreshToken();

                        var savedRefreshToken = await _refreshTokenRepo.SaveRefreshTokenAsync(
                            new RefreshToken { Token = refreshToken, AppUserId = appUser.Id }
                        );

                        return Ok(
                            new AuthResponse
                            {
                                Email = appUser.Email,
                                AccessToken = _tokenService.CreateJWT(appUser),
                                RefreshToken = savedRefreshToken.Token,
                                RefreshTokenExpiry = savedRefreshToken.Expires,
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
                    if (createdUser.Errors.Any(err => err.Code == "DuplicateEmail"))
                    {
                        return StatusCode(
                            400,
                            new ErrorResponse { Message = "That Email is already taken" }
                        );
                    }
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
