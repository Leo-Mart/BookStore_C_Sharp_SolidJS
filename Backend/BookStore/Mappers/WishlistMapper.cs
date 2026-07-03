using BookStore.Models.Wishlists;

namespace BookStore.Mappers
{
    public static class WishlistMapper
    {
        public static WishlistInfoDto ToInfoDtoFromWishlist(this Wishlist wishlist)
        {
            return new WishlistInfoDto
            {
                AppUserId = wishlist.AppUserId,
                Name = wishlist.Name,
                IsDefault = wishlist.IsDefault,
                Description = wishlist.Description,
                WishlistItems = wishlist.WishlistItems
                        .Select(wli => wli.ToListItemInfoDtoFromListItem()).ToList()
            };
        }

        public static WishlistItemInfoDto ToListItemInfoDtoFromListItem(this WishlistItem wishlistItem)
        {
            return new WishlistItemInfoDto
            {
                BookId = wishlistItem.BookId,
                WishListId = wishlistItem.WishListId
            };
        }
    }
}