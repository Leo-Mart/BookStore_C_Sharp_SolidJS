using BookStore.Models.Wishlists;

namespace BookStore.Interfaces
{
    public interface IWishlistService
    {
        Task<Wishlist?> CreateNewWishList(string userId, CreateWishlistDto wishlist);
        Task<WishlistItemInfoDto?> AddNewItemToWishlist(int? wishlistId, CreateWishlistItemDto wishlistItem);
        Task<WishlistItemInfoDto?> RemoveItemFromWishlist(int? wishlistId, int wishlistItemId);
        Task<ICollection<WishlistInfoDto>?> GetUserWishlists(string userId);
        Task<WishlistInfoDto?> GetOneWishlistForUser(string userId, int wishlistId);
        Task<WishlistInfoDto?> DeleteWishlist(int wishlistId);
        Task<WishlistInfoDto?> MarkWishlistAsDefault(int wishlistId);
    }

}