using BookStore.DbContexts;
using BookStore.Interfaces;
using BookStore.Models.Wishlists;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class WishlistRepository(ApplicationDbContext context) : IWishlistRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<WishlistItem?> AddItemToWishListAsync(int wishlistId, WishlistItem wishlistItem)
        {
            var wishlistFromDb = await _context.Wishlists.Where(wl => wl.Id == wishlistId).FirstOrDefaultAsync();
            if (wishlistFromDb == null)
            {
                return null;
            }

            wishlistFromDb.UpdatedAt = DateTime.UtcNow;

            wishlistItem.UpdatedAt = DateTime.UtcNow;
            wishlistItem.CreatedAt = DateTime.UtcNow;
            wishlistItem.WishListId = wishlistFromDb.Id;

            await _context.WishlistItems.AddAsync(wishlistItem);
            await _context.SaveChangesAsync();

            return wishlistItem;
        }

        public async Task<Wishlist> CreateNewWishlistAsync(Wishlist wishlist)
        {
            wishlist.CreatedAt = DateTime.UtcNow;
            wishlist.UpdatedAt = DateTime.UtcNow;

            await _context.Wishlists.AddAsync(wishlist);
            await _context.SaveChangesAsync();

            return wishlist;
        }

        public async Task<Wishlist?> DeleteWishlistByIdAsync(int wishlistId)
        {
            var foundWishlist = await _context.Wishlists.Where(wl => wl.Id == wishlistId).FirstOrDefaultAsync();

            if (foundWishlist == null)
            {
                return null;
            }

            _context.Wishlists.Remove(foundWishlist);
            await _context.SaveChangesAsync();

            return foundWishlist;
        }

        public async Task<WishlistInfoDto?> GetSingleWishlistForUserByIdAsync(string userId, int wishlistId)
        {
            return await _context.Wishlists
                .Where(wl => wl.Id == wishlistId && wl.AppUserId == Guid.Parse(userId))
                .Select(wl => new WishlistInfoDto
                {
                    AppUserId = wl.AppUserId,
                    Name = wl.Name,
                    IsDefault = wl.IsDefault,
                    Description = wl.Description,
                    WishlistItems = wl.WishlistItems.Select(wli => new WishlistItemInfoDto
                    {
                        BookId = wli.BookId,
                        WishListId = wli.WishListId
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<WishlistInfoDto>?> GetWishlistsForUserByUserIdAsync(string userId)
        {
            return await _context.Wishlists
                .Where(wl => wl.AppUserId == Guid.Parse(userId))
                .Select(wl => new WishlistInfoDto
                {
                    AppUserId = wl.AppUserId,
                    Name = wl.Name,
                    IsDefault = wl.IsDefault,
                    Description = wl.Description,
                    WishlistItems = wl.WishlistItems.Select(wli => new WishlistItemInfoDto
                    {
                        BookId = wli.BookId,
                        WishListId = wli.WishListId
                    }).ToList()
                }).ToListAsync();

        }

        public async Task<Wishlist?> MarkWishlistDefaultAsync(int wishlistId)
        {
            var wishlistFromDB = await _context.Wishlists.Where(wl => wl.Id == wishlistId).FirstOrDefaultAsync();
            if (wishlistFromDB == null)
            {
                return null;
            }

            if (wishlistFromDB.IsDefault == true)
            {
                //TODO: send back a proper "this wishlist is already the default" or similar error
                return null;
            }

            wishlistFromDB.IsDefault = true;
            wishlistFromDB.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return wishlistFromDB;
        }

        public async Task<WishlistItem?> RemoveItemFromWishListAsync(int wishlistId, int wishlistItemId)
        {
            var wishlistFromDb = await _context.Wishlists.Where(wl => wl.Id == wishlistId).FirstOrDefaultAsync();
            if (wishlistFromDb == null)
            {
                return null;
            }

            var foundWLItem = wishlistFromDb.WishlistItems.FirstOrDefault(wli => wli.Id == wishlistItemId);
            if (foundWLItem == null)
            {
                return null;
            }

            wishlistFromDb.UpdatedAt = DateTime.UtcNow;
            wishlistFromDb.WishlistItems.Remove(foundWLItem);
            await _context.SaveChangesAsync();

            return foundWLItem;
        }
    }
}