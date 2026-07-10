using BookStore.DbContexts;
using BookStore.Interfaces;
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
                    return null;
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
                return null;
            }

            var foundAddresses = await _addressRepo.GetAddressesForUserAsync(userId);

            if (foundAddresses == null)
            {
                return null;
            }

            var response = new CustomerDto { Addresses = foundAddresses };

            return response;
        }

        public async Task<CustomerDto?> GetCustomerOrders(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return null;
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
                return null;
            }

            var foundWishlists = await _wishlistRepo.GetWishlistsForUserByUserIdAsync(userId);
            if (foundWishlists == null)
            {
                return null;
            }

            var response = new CustomerDto { Wishlists = foundWishlists };

            return response;
        }
    }
}

