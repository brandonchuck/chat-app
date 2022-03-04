using chat_app.Controllers;
using Chat_App_DAL.Interfaces;
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
        IUserRepository _userRepository;

        public AuthenticationService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }


        // Verify User
        public async Task<User> AuthenticateUser(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username);
        }


        // Verify Password
        public bool ValidatePassword(string formPassword, string dbPassword)
        {
            return BCrypt.Net.BCrypt.Verify(formPassword, dbPassword);
        }


        // Generate JWT
        public string GenerateAuthToken(User user)
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
                //_configuration["JWT:Issuer"],  // issuer is the server 
                //_configuration["JWT:Audience"], // audience is the browser
                issuer: null,
                audience: null,
                claims,
                expires: DateTime.Now.AddHours(24), // token expires after 24 hours
                signingCredentials: credentials
            );

            // write a new jwt token and return to client
            return new JwtSecurityTokenHandler().WriteToken(authToken);
        }
    }
}
