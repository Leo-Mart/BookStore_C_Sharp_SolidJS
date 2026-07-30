using BookStore.Models.Users;

namespace BookStore.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> SaveRefreshTokenAsync(RefreshToken refreshToken);
        Task<RefreshToken?> RefreshTokenExistsAsync(string refreshToken);
        Task RevokeAllActiveRefreshTokensAsync(string userId);
        Task<RefreshToken?> RevokeRefreshToken(RefreshToken refreshToken);
    }
}
