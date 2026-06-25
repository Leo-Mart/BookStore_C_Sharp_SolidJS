using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookStore.Extensions
{
    public static class ClaimsExtensions
    {
        public static string? GetUserId(this ClaimsPrincipal user)
        {
            // var claim = user.FindFirst("sub"); 
            var claim = user.FindFirst(ClaimTypes.NameIdentifier);
            return claim?.Value;
        }
    }
}