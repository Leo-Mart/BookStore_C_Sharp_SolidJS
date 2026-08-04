using BookStore.DbContexts;
using BookStore.Interfaces;
using BookStore.Models.Users;

namespace BookStore.Repository
{
    public class RefreshTokenRepository(ApplicationDbContext context) : IRefreshTokenRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<RefreshToken?> RefreshTokenExistsAsync(string refreshToken)
        {
            return _context.RefreshTokens.FirstOrDefault(t => t.Token == refreshToken);
        }

        public async Task RevokeAllActiveRefreshTokensAsync(string userId)
        {
            var activeRefreshTokens = _context
                .RefreshTokens.Where(t => t.AppUserId == userId && t.Revoked == null)
                .ToList();

            foreach (var token in activeRefreshTokens)
            {
                token.Revoked = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<RefreshToken?> RevokeRefreshToken(RefreshToken refreshToken)
        {
            var tokenToRevoke = _context.RefreshTokens.FirstOrDefault(t =>
                t.Token == refreshToken.Token
            );
            if (tokenToRevoke == null)
            {
                return null;
            }
            tokenToRevoke.UpdatedAt = DateTime.UtcNow;
            tokenToRevoke.Revoked = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return tokenToRevoke;
        }

        public async Task<RefreshToken> SaveRefreshTokenAsync(RefreshToken refreshToken)
        {
            refreshToken.CreatedAt = DateTime.UtcNow;
            refreshToken.UpdatedAt = DateTime.UtcNow;
            refreshToken.Expires = DateTime.UtcNow.AddDays(30);

            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
            return refreshToken;
        }
    }
}
