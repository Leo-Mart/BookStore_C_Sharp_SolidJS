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
        IEmailSender<AppUser> mailService
    ) : IAccountService
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly ILogger<AccountService> _logger = logger;
        private readonly SignInManager<AppUser> _signInManager = signInManager;
        private readonly ITokenService _tokenService = tokenService;
        private readonly IRefreshTokenRepository _refreshTokenRepo = refreshTokenRepo;
        private readonly ApplicationDbContext _context = context;
        private readonly IEmailSender<AppUser> _mailService = mailService;

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

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                throw new UnauthorizedRequestException("Email is not confirmed", 400);
            }

            //TODO: add other checks here, isLockedOUt, phoneConfirm etc possibly with custom errors

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

        public async Task RegisterNewUser(RegisterDto registerDto)
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

                    await GenerateEmailConfirmationTokenForUser(appUser.Email);
                    return;
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

        public async Task ChangeUserPassword(string userId, string oldPassword, string newPassword)
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

            return;
        }

        public async Task GeneratePasswordResetTokenForUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return;
            }

            if (user != null)
            {
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var encodedToken = Uri.EscapeDataString(resetToken);
                var resetUrl =
                    $"http://localhost:3000/reset-password?token={encodedToken}&userEmail={user.Email}";

                await _mailService.SendPasswordResetLinkAsync(user, user.Email, resetUrl);

                return;
            }

            return;
        }

        public async Task ResetUserPassword(
            string email,
            string passwordResetToken,
            string newPassword
        )
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return;
            }
            var result = await _userManager.ResetPasswordAsync(
                user,
                passwordResetToken,
                newPassword
            );

            if (!result.Succeeded)
            {
                return;
            }

            return;
        }

        public async Task GenerateEmailConfirmationTokenForUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return;
            }

            if (user != null)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var encodedToken = Uri.EscapeDataString(token);
                var confirmUrl =
                    $"http://localhost:3000/register/confirm-email?userEmail={user.Email}&token={encodedToken}";
                await _mailService.SendConfirmationLinkAsync(user, user.Email, confirmUrl);
                return;
            }

            return;
        }

        public async Task ConfirmUserEmail(string email, string emailConfirmationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return;
            }
            var result = await _userManager.ConfirmEmailAsync(user, emailConfirmationToken);

            if (!result.Succeeded)
            {
                return;
            }

            return;
        }
    }
}
