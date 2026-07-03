using BookStore.Models.Wishlists;

namespace BookStore.Interfaces
{
    public interface IWishlistRepository
    {
        Task<Wishlist> CreateNewWishlistAsync(Wishlist wishList);
        Task<WishlistItem?> AddItemToWishListAsync(int wishlistId, WishlistItem wishlistItem);
        Task<WishlistItem?> RemoveItemFromWishListAsync(int wishlistId, int wishlistItemId);
        Task<ICollection<WishlistInfoDto>?> GetWishlistsForUserByUserIdAsync(string userId);
        Task<WishlistInfoDto?> GetSingleWishlistForUserByIdAsync(string userId, int wishlistId);
        Task<Wishlist?> MarkWishlistDefaultAsync(int wishlistId);
        Task<Wishlist?> DeleteWishlistByIdAsync(int wishlistId);
    }
}