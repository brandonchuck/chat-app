using Chat_App_DAL.Interfaces;
using Chat_App_DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UserDTO userDTO)
        {
            User currentUser = await _authenticationService.AuthenticateUser(userDTO.Username);
            if (currentUser == null)
            {
                return BadRequest("User not found");
            }

            // create method that validates the password and returns true or false
            // determine if password hash matches password hash stored in db
            bool isValidPassword = _authenticationService.ValidatePassword(userDTO.Password, currentUser.Password);
            if (!isValidPassword)
            {
                return BadRequest("Wrong password");
            }

            // generate new jwt
            string jwtToken = _authenticationService.GenerateAuthToken(currentUser);
            return Ok(jwtToken);
        }


        [HttpPost("signup")]
        public async Task<User> Signup([FromBody] User user)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password); // this hash contains the salt
            user.Password = passwordHash;
            var newUser = await _userRepository.CreateNewUserAsync(user);
            return newUser;
        }

    }
}