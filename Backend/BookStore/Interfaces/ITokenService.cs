using BookStore.Models.Users;

namespace BookStore.Interfaces
{
    public interface ITokenService
    {
        string CreateJWT(AppUser user);
        string CreateRefreshToken();
        Task<(RefreshToken?, AppUser?)> RefreshTokenAsync(string refreshToken);
    }
}
