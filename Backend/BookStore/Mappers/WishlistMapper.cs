using BookStore.Models.Wishlists;

namespace BookStore.Mappers
{
    public static class WishlistMapper
    {
        public static WishlistInfoDto ToInfoDtoFromWishlist(this Wishlist wishlist)
        {
            return new WishlistInfoDto
            {
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
                WishlistId = wishlistItem.WishListId
            };
        }

        public static Wishlist ToWishlistFromCreateDto(this CreateWishlistDto createWishlist)
        {
            return new Wishlist
            {
                Name = createWishlist.Name,
                IsDefault = createWishlist.IsDefault,
                Description = createWishlist.Description,
            };
        }

        public static WishlistItem ToListItemFromCreateItemDto(this CreateWishlistItemDto itemDto)
        {
            return new WishlistItem
            {
                BookId = itemDto.BookId,
            };
        }
    }
}