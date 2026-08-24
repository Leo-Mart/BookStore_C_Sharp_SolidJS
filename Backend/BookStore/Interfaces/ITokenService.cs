using BookStore.Models.Users;

namespace BookStore.Interfaces
{
    public interface ITokenService
    {
        string CreateJWT(AppUser user);
        string CreateRefreshToken();
        Task<(RefreshToken?, AppUser?)> RefreshTokenAsync(string refreshToken);
        void SetTokensInsideCookie(
            string accessToken,
            string refreshToken,
            IHttpContextAccessor context
        );
    }
}
