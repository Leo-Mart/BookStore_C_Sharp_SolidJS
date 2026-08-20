using BookStore.DbContexts;
using BookStore.Exceptions;
using BookStore.Interfaces;
using BookStore.Models.Users;
using BookStore.Models.Wishlists;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Services
{
    public class AccountService(
        ILogger<AccountService> logger,
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        ApplicationDbContext context,
        ITokenService tokenService,
        IRefreshTokenRepository refreshTokenRepo,
        IEmailService mailService
    ) : IAccountService
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly ILogger<AccountService> _logger = logger;
        private readonly SignInManager<AppUser> _signInManager = signInManager;
        private readonly ITokenService _tokenService = tokenService;
        private readonly IRefreshTokenRepository _refreshTokenRepo = refreshTokenRepo;
        private readonly ApplicationDbContext _context = context;
        private readonly IEmailService _mailService = mailService;

        public async Task<AuthResponse> LoginUser(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                throw new UnauthorizedRequestException(
                    "Username not found and/or password incorrect",
                    401
                );

            var result = await _signInManager.CheckPasswordSignInAsync(
                user,
                loginDto.Password,
                false
            );

            if (!result.Succeeded)
                throw new UnauthorizedRequestException(
                    "Username not found and/or password incorrect",
                    401
                );

            var refreshToken = _tokenService.CreateRefreshToken();

            var savedRefreshToken = await _refreshTokenRepo.SaveRefreshTokenAsync(
                new RefreshToken { Token = refreshToken, AppUserId = user.Id }
            );

            var response = new AuthResponse
            {
                Email = user.Email,
                AccessToken = _tokenService.CreateJWT(user),
                RefreshToken = savedRefreshToken.Token,
                RefreshTokenExpiry = savedRefreshToken.Expires,
            };

            return response;
        }

        public async Task LogoutUser(RefreshTokenDto refreshDto)
        {
            var foundToken = await _refreshTokenRepo.RefreshTokenExistsAsync(
                refreshDto.RefreshToken
            );
            if (foundToken == null || !foundToken.IsActive)
                throw new UnauthorizedRequestException("Invalid or missing refresh token", 401);

            await _refreshTokenRepo.RevokeRefreshToken(foundToken);
        }

        public async Task<AuthResponse> RefreshAccessToken(RefreshTokenDto refreshDto)
        {
            var (newRefreshToken, user) = await _tokenService.RefreshTokenAsync(
                refreshDto.RefreshToken
            );
            if (newRefreshToken == null)
                throw new UnauthorizedRequestException("Invalid or missing refresh token", 401);

            var response = new AuthResponse
            {
                Email = user.Email,
                AccessToken = _tokenService.CreateJWT(user),
                RefreshToken = newRefreshToken.Token,
                RefreshTokenExpiry = newRefreshToken.Expires,
            };

            return response;
        }

        public async Task<AuthResponse> RegisterNewUser(RegisterDto registerDto)
        {
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
                    var response = new AuthResponse
                    {
                        Email = appUser.Email,
                        AccessToken = _tokenService.CreateJWT(appUser),
                        RefreshToken = savedRefreshToken.Token,
                        RefreshTokenExpiry = savedRefreshToken.Expires,
                    };

                    await GenerateEmailConfirmationTokenForUser(appUser.Email);

                    return response;
                }
                else
                {
                    throw new UserRegistrationException("Error creating user", null, 500);
                }
            }
            else
            {
                if (createdUser.Errors.Any(err => err.Code == "DuplicateEmail"))
                {
                    throw new UserRegistrationException("Email already in use", null, 400);
                }
                throw new UserRegistrationException(
                    "Error creating user ",
                    createdUser.Errors,
                    500
                );
            }
        }

        public async Task<bool> ChangeUserPassword(
            string userId,
            string oldPassword,
            string newPassword
        )
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new UnauthorizedRequestException("Unauthorized", 401);
            }

            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            if (!result.Succeeded)
            {
                throw new UserRegistrationException("Error resetting password", result.Errors, 500);
            }

            return result.Succeeded;
        }

        public async Task<bool> GeneratePasswordResetTokenForUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new UnauthorizedRequestException("Unauthorized", 401);
            }

            if (user != null)
            {
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                // send an email with the token to the users address, (take the one from the found user object)
                // return nocontent in either case, don't want to expose wether the user was found or not.
                return true;
            }

            return false;
            // return nocontent in either case, don't want to expose wether the user was found or not.
        }

        public async Task<bool> ResetUserPassword(
            string email,
            string passwordResetToken,
            string newPassword
        )
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new UnauthorizedRequestException("Unauthorized", 401);
            }
            var result = _userManager.ResetPasswordAsync(user, passwordResetToken, newPassword);

            if (!result.IsCompletedSuccessfully)
            {
                return false;
            }

            return result.IsCompletedSuccessfully;
        }

        public async Task<bool> GenerateEmailConfirmationTokenForUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new UnauthorizedRequestException("Unauthorized", 401);
            }

            if (user != null)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                await _mailService.SendConfirmationEmailToUser(token, user.FirstName, user.Email);
                return false;
            }

            return false;
        }

        public async Task<bool> ConfirmUserEmail(string email, string emailConfirmationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new UnauthorizedRequestException("Unauthorized", 401);
            }
            var result = await _userManager.ConfirmEmailAsync(user, emailConfirmationToken);

            if (!result.Succeeded)
            {
                return false;
            }

            return result.Succeeded;
        }
    }
}
