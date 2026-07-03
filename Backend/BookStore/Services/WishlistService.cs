using BookStore.DbContexts;
using BookStore.Interfaces;
using BookStore.Mappers;
using BookStore.Models.Users;
using BookStore.Models.Wishlists;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Services
{
    public class WishlistService(UserManager<AppUser> userManager, IWishlistRepository wishlistRepo, ApplicationDbContext context) : IWishlistService
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IWishlistRepository _wishListRepo = wishlistRepo;
        private readonly ApplicationDbContext _context = context;
        public async Task<WishlistItemInfoDto?> AddNewItemToWishlist(int? wishlistId, CreateWishlistItemDto wishlistItem)
        {
            WishlistItem? savedItem;
            if (wishlistId == null)
            {
                savedItem = await _wishListRepo.AddItemToWishListAsync(null, wishlistItem.ToListItemFromCreateItemDto());

            }
            else
            {
                savedItem = await _wishListRepo.AddItemToWishListAsync(wishlistId, wishlistItem.ToListItemFromCreateItemDto());
            }

            if (savedItem == null)
            {
                return null;
            }

            return savedItem.ToListItemInfoDtoFromListItem();

        }

        public async Task<WishlistInfoDto?> CreateNewWishList(string userId, CreateWishlistDto wishlist)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return null;
            }

            Wishlist newWishlist = wishlist.ToWishlistFromCreateDto();
            newWishlist.AppUserId = Guid.Parse(userId);

            var createdWishlist = await _wishListRepo.CreateNewWishlistAsync(newWishlist);
            if (createdWishlist == null)
            {
                return null;
            }

            return createdWishlist.ToInfoDtoFromWishlist();
        }

        public async Task<WishlistInfoDto?> DeleteWishlist(int wishlistId)
        {
            var deletedWishlist = await _wishListRepo.DeleteWishlistByIdAsync(wishlistId);
            if (deletedWishlist == null)
            {
                return null;
            }

            return deletedWishlist.ToInfoDtoFromWishlist();
        }

        public async Task<WishlistInfoDto?> GetOneWishlistForUser(string userId, int wishlistId)
        {
            return await _wishListRepo.GetSingleWishlistForUserByIdAsync(userId, wishlistId);
        }

        public async Task<ICollection<WishlistInfoDto>?> GetUserWishlists(string userId)
        {
            return await _wishListRepo.GetWishlistsForUserByUserIdAsync(userId);
        }

        public async Task<WishlistInfoDto?> MarkWishlistAsDefault(int wishlistId)
        {
            var updatedWishlist = await _wishListRepo.MarkWishlistDefaultAsync(wishlistId);
            if (updatedWishlist == null)
            {
                return null;
            }

            return updatedWishlist.ToInfoDtoFromWishlist();
        }

        public async Task<WishlistItemInfoDto?> RemoveItemFromWishlist(int? wishlistId, int wishlistItemId)
        {
            WishlistItem? removedItem;
            if (wishlistId == null)
            {
                removedItem = await _wishListRepo.RemoveItemFromWishListAsync(null, wishlistItemId);

            }
            else
            {
                removedItem = await _wishListRepo.RemoveItemFromWishListAsync(wishlistId, wishlistItemId);
            }

            if (removedItem == null)
            {
                return null;
            }

            return removedItem.ToListItemInfoDtoFromListItem();
        }
    }
}