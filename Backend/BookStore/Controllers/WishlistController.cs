using BookStore.Extensions;
using BookStore.Interfaces;
using BookStore.Mappers;
using BookStore.Models.Wishlists;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/wishlists/")]
    [Authorize]
    public class WishlistController(
        ILogger<WishlistController> logger,
        IWishlistService wishlistService
    ) : ControllerBase
    {
        private readonly IWishlistService _wishlistService = wishlistService;
        private readonly ILogger<WishlistController> _logger = logger;

        [HttpGet]
        public async Task<ActionResult<ICollection<WishlistInfoDto>>> GetWishlists()
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var wishlists = await _wishlistService.GetUserWishlists(userId);
            if (wishlists == null)
            {
                return NotFound("No wishlists found for user");
            }

            return Ok(wishlists);
        }

        [HttpGet("{wishlistId}", Name = "GetWishlist")]
        public async Task<ActionResult<ICollection<WishlistInfoDto>>> GetWishlist(int wishlistId)
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var wishlists = await _wishlistService.GetOneWishlistForUser(userId, wishlistId);
            if (wishlists == null)
            {
                return NotFound("No wishlists found for user");
            }

            return Ok(wishlists);
        }

        [HttpPost]
        public async Task<ActionResult<WishlistInfoDto>> CreateNewWishlist(
            [FromBody] CreateWishlistDto wishlist
        )
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var wishlistToSave = await _wishlistService.CreateNewWishList(userId, wishlist);

            if (wishlistToSave == null)
            {
                return Unauthorized();
            }

            return CreatedAtAction(
                "GetWishlist",
                new { userId, wishlistId = wishlistToSave.Id },
                wishlistToSave.ToInfoDtoFromWishlist()
            );
        }

        [HttpDelete("{wishlistId}")]
        public async Task<ActionResult> DeleteWishlist(int wishlistId)
        {
            var deletedWishlist = await _wishlistService.DeleteWishlist(wishlistId);
            if (deletedWishlist == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("{wishlistId}/add-item")]
        public async Task<ActionResult<WishlistItemInfoDto>> AddItemToWishlist(
            int wishlistId,
            [FromBody] CreateWishlistItemDto wishlistItem
        )
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var itemToSave = await _wishlistService.AddNewItemToWishlist(wishlistId, wishlistItem);

            if (itemToSave == null)
            {
                return Unauthorized();
            }

            return CreatedAtAction("GetWishlist", new { userId, wishlistId }, itemToSave);
        }

        [HttpPut("{wishlistId}/mark-default")]
        public async Task<ActionResult> MarkDefaultWishlist(int wishlistId)
        {
            var markedWishlist = await _wishlistService.MarkWishlistAsDefault(wishlistId);
            if (markedWishlist == null)
            {
                return NotFound();
            }

            return Ok(markedWishlist);
        }

        [HttpDelete("{wishlistId}/remove-item/{itemId}")]
        public async Task<ActionResult> DeleteItemFromWishlist(int wishlistId, int itemId)
        {
            var deletedItem = await _wishlistService.RemoveItemFromWishlist(wishlistId, itemId);
            if (deletedItem == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

