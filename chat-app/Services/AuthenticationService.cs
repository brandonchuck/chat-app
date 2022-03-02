using chat_app.Controllers;
using Chat_App_DAL.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace chat_app.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        IConfiguration _configuration;

        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var credentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

            // define claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
            };

            // create JWT
            var authToken = new JwtSecurityToken(
                _configuration["JWT:Issuer"],  // issuer is the server 
                _configuration["JWT:Audience"], // audience is the browser
                claims,
                expires: DateTime.Now.AddHours(24), // token expires after 24 hours
                signingCredentials: credentials
            );

            // write a new jwt token and return to client
            return new JwtSecurityTokenHandler().WriteToken(authToken);
        }
    }
}
