using Chat_App_DAL.DTOs;
using Chat_App_DAL.Interfaces;
using Chat_App_DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Web.Services3.Referral;

namespace chat_app.Controllers
{

    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IUserRepository userRepository, IAuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
        }

        // Log in user
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDTO loginDTO)
        {
            User currentUser = await _authenticationService.AuthenticateUser(loginDTO.Username);
            if (currentUser == null)
            {
                return BadRequest("User not found");
            }

            // Check if password matches stored password -- return true or false
            bool isValidPassword = _authenticationService.ValidatePassword(loginDTO.Password, currentUser.Password);
            if (!isValidPassword)
            {
                return BadRequest("Wrong password");
            }

            // generate new jwt
            string jwtToken = _authenticationService.GenerateAuthToken(currentUser);

            return Ok(new { token = jwtToken });
        }

        // Sign up new user
        [HttpPost("signup")]
        public async Task<User> Signup([FromBody] SignupDTO signupDTO)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(signupDTO.Password); // this hash contains the salt
            signupDTO.Password = passwordHash;

            // create User from signupDTO object
            var user = new User
            {
                Username = signupDTO.Username,
                Password = passwordHash,
                FirstName = signupDTO.FirstName,
                LastName = signupDTO.LastName,
            };

            var newUser = await _userRepository.CreateNewUserAsync(user);
            return newUser;
        }

    }
}