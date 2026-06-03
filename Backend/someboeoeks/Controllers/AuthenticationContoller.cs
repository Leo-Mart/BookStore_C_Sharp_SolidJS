using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using someboeoeks.Interfaces;
using someboeoeks.Mappers;
using someboeoeks.Models.Users;

namespace someboeoeks.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationContoller : ControllerBase
    {
        private readonly IUserRepository _userRepoo;
        private readonly IConfiguration _config;
        public AuthenticationContoller(IUserRepository userRepo, IConfiguration config)
        {
            _userRepoo = userRepo;
            _config = config;
        }
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

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString()));
            claimsForToken.Add(new Claim("given_name", user.FirstName));
            claimsForToken.Add(new Claim("family_name", user.LastName));

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

        private async Task<ResponseUserDto> ValideUserCredentials(string? email, string? password)
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