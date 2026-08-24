using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using BookStore.Interfaces;
using BookStore.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        private readonly IRefreshTokenRepository _refreshTokenRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<TokenService> _logger;

        public TokenService(
            UserManager<AppUser> userManager,
            IRefreshTokenRepository refreshTokenRepo,
            IConfiguration config,
            ILogger<TokenService> logger
        )
        {
            _config = config;
            _key = new SymmetricSecurityKey(Convert.FromBase64String(_config["JWT:SigningKey"]));
            _refreshTokenRepo = refreshTokenRepo;
            _userManager = userManager;
        }

        public string CreateJWT(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            };

            var signingCredentials = new SigningCredentials(
                _key,
                SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = signingCredentials,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"],
                IssuedAt = DateTime.UtcNow,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string CreateRefreshToken()
        {
            var randomBytes = RandomNumberGenerator.GetBytes(64);
            return Convert.ToBase64String(randomBytes);
        }

        public async Task<(RefreshToken?, AppUser?)> RefreshTokenAsync(string refreshToken)
        {
            var foundRefreshToken = await _refreshTokenRepo.RefreshTokenExistsAsync(refreshToken);
            if (foundRefreshToken == null)
            {
                return (null, null);
            }

            var user = await _userManager.FindByIdAsync(foundRefreshToken.AppUserId);
            if (user == null)
            {
                return (null, null);
            }

            if (!foundRefreshToken.IsActive)
            {
                if (foundRefreshToken.Revoked != null)
                {
                    await _refreshTokenRepo.RevokeAllActiveRefreshTokensAsync(
                        foundRefreshToken.AppUserId
                    );
                }
                return (null, null);
            }

            var revokedToken = await _refreshTokenRepo.RevokeRefreshToken(foundRefreshToken);

            var newRefreshToken = CreateRefreshToken();
            var savedRefreshToken = await _refreshTokenRepo.SaveRefreshTokenAsync(
                new RefreshToken { Token = newRefreshToken, AppUserId = user.Id }
            );

            return (savedRefreshToken, user);
        }

        public void SetTokensInsideCookie(
            string accessToken,
            string refreshToken,
            IHttpContextAccessor ctx
        )
        {
            ctx.HttpContext.Response.Cookies.Append(
                "accessToken",
                accessToken,
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddHours(1),
                    HttpOnly = true,
                    IsEssential = true,
                    Secure = true,
                    SameSite = SameSiteMode.Lax,
                }
            );

            ctx.HttpContext.Response.Cookies.Append(
                "refreshToken",
                refreshToken,
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(30),
                    HttpOnly = true,
                    IsEssential = true,
                    Secure = true,
                    SameSite = SameSiteMode.Lax,
                }
            );
        }
    }
}
