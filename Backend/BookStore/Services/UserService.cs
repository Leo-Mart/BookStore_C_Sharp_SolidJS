using BookStore.DbContexts;
using BookStore.Exceptions;
using BookStore.Interfaces;
using BookStore.Models.Addresses;
using BookStore.Models.Reviews;
using BookStore.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Services
{
    public class UserService(
        UserManager<AppUser> userManager,
        IOrderRepository orderRepo,
        IAddressRepository addressRepo,
        IWishlistRepository wishlistRepo,
        IReviewRepository reviewRepo,
        ApplicationDbContext context
    ) : IUserService
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IOrderRepository _orderRepo = orderRepo;
        private readonly IAddressRepository _addressRepo = addressRepo;
        private readonly IReviewRepository _reviewRepo = reviewRepo;
        private readonly IWishlistRepository _wishlistRepo = wishlistRepo;
        private readonly ApplicationDbContext _context = context;

        public async Task<CustomerDto?> GetCustomerInfo(string userId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    throw new UnAuthorizedRequestException("Unauthorized", 401);
                }

                var foundOrders = await _orderRepo.GetOrdersForUserAsync(userId);

                var foundAddresses = await _addressRepo.GetAddressesForUserAsync(userId);

                var foundReviews = await _reviewRepo.GetReviewsForUserByIdAsync(userId);

                var foundWishlists = await _wishlistRepo.GetWishlistsForUserByUserIdAsync(userId);

                var userResponse = new CustomerDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Addresses = foundAddresses ?? [],
                    Reviews = foundReviews ?? [],
                    Orders = foundOrders ?? [],
                    Wishlists = foundWishlists ?? [],
                };

                return userResponse;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<CustomerDto?> GetCustomerAddresses(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new UnAuthorizedRequestException("Unauthorized", 401);
            }

            var foundAddresses = await _addressRepo.GetAddressesForUserAsync(userId);

            if (foundAddresses == null)
            {
                return null;
            }

            var response = new CustomerDto { Addresses = foundAddresses };

            return response;
        }

        public async Task<AddressInfoDto?> GetCustomerDefaultAddress(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new UnAuthorizedRequestException("Unauthorized", 401);
            }

            var foundDefaultAddress = await _addressRepo.GetDefaultAddressForUserAsync(userId);

            if (foundDefaultAddress == null)
            {
                return null;
            }

            return foundDefaultAddress;
        }

        public async Task<CustomerDto?> GetCustomerOrders(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new UnAuthorizedRequestException("Unauthorized", 401);
            }
            var foundOrders = await _orderRepo.GetOrdersForUserAsync(userId);

            if (foundOrders == null)
            {
                return null;
            }

            var response = new CustomerDto { Orders = foundOrders };

            return response;
        }

        public async Task<CustomerDto?> GetCustomerWishlists(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new UnAuthorizedRequestException("Unauthorized", 401);
            }

            var foundWishlists = await _wishlistRepo.GetWishlistsForUserByUserIdAsync(userId);
            if (foundWishlists == null)
            {
                return null;
            }

            var response = new CustomerDto { Wishlists = foundWishlists };

            return response;
        }

        public async Task<IEnumerable<ReviewInfoDto>?> GetCustomerReviews(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new UnAuthorizedRequestException("Unauthorized", 401);
            }

            var foundReviews = await _reviewRepo.GetReviewsForUserByIdAsync(userId);
            if (foundReviews == null)
            {
                return null;
            }

            return foundReviews;
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
                throw new UnAuthorizedRequestException("Unauthorized", 401);
            }

            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            if (!result.Succeeded)
            {
                return false;
            }

            return result.Succeeded;
        }

        public async Task<bool> GeneratePasswordResetTokenForUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new UnAuthorizedRequestException("Unauthorized", 401);
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
                throw new UnAuthorizedRequestException("Unauthorized", 401);
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
                throw new UnAuthorizedRequestException("Unauthorized", 401);
            }

            if (user != null)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                // send the confirmation email to the found user with the token
                return false;
            }

            return false;
        }

        public async Task<bool> ConfirmUserEmail(string email, string emailConfirmationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new UnAuthorizedRequestException("Unauthorized", 401);
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
