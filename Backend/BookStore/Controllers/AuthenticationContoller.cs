using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BookStore.Interfaces;
using BookStore.Mappers;
using BookStore.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationContoller(IUserRepository userRepo, IConfiguration config) : ControllerBase
    {
        private readonly IUserRepository _userRepoo = userRepo;
        private readonly IConfiguration _config = config;

    public class AuthenticationRequestBody
        {
            public string? Email { get; set; }
            public string? Password { get; set; }
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<string>> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {
            var user = await ValideUserCredentials(authenticationRequestBody.Email, authenticationRequestBody.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(_config["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
            {
              new("sub", user.Id.ToString()),
              new("given_name", user.FirstName),
              new("family_name", user.LastName)
            };

            var jwtSecurityToken = new JwtSecurityToken(
                _config["Authentication:Issuer"],
                _config["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials
            );

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }

        private async Task<ResponseUserDto?> ValideUserCredentials(string? email, string? password)
        {
            var foundUser = await _userRepoo.GetUserByEmailAsync(email);

            if (foundUser == null)
            {
                return null;
            }

            if (foundUser.Password != password)
            {
                return null;
            }

            return foundUser.ToResponseUserDtoFromUser();
        }
    }
}