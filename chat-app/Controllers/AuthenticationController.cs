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

        /// <summary>
        /// - Returns a JWT to client if username and password exist
        /// - Redirect user to /chatrooms endpoint on frontend
        /// - Pass JWT to client as a cookie
        /// - Cookie will be stored in session storage in the client
        /// - Client uses JWT token from the cookie to access other endpoints
        ///     - Use JWT like a bearer token by adding to request header: "Authorization", "Bearer <JWT>"
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UserDTO userDTO)
        {
            // create method that locates the User object in db and returns it by username
            User currentUser = await _userRepository.GetUserByUsernameAsync(userDTO.Username);
            if (currentUser == null)
            {
                return BadRequest("User not found");
            }

            // create method that validates the password and returns true or false
            // determine if password hash matches password hash stored in db
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(userDTO.Password, currentUser.Password);
            if (!isValidPassword)
            {
                return BadRequest("Wrong password");
            }

            // generate new jwt
            string jwtToken = _authenticationService.GenerateToken(currentUser);
            return Ok(jwtToken);
        }


        /// <summary>
        /// Signs up a user with a new username and password
        /// 1. Takes username and checks if it exists in database already
        /// 2. If user does not exist, then CREATE new user in "users" table with username, password, and UUID
        /// 3. Redirect to /login on frontend
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        [HttpPost("signup")]
        public async Task<User> Signup([FromBody] User user) // possibly create a UserDTO to grab firstname, lastname, username, password
        {
            // TODO:
            // 1. Generate Salt
            // 2. Grab password from JSON body
            // 3. Concatenate salt and password
            // 4. Run this salt+password string through hashing algo
            // 5. Concatentate original salt to this hash
            // 6. Store this as the password in database

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password); // this hash has the salt appended to it
            user.Password = passwordHash;
            var newUser = await _userRepository.CreateNewUserAsync(user);
            return newUser;
        }

    }
}