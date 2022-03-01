using Chat_App_DAL.Interfaces;
using Chat_App_DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace chat_app.Controllers
{

    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public AuthenticationController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
        [Route("login")]
        [HttpPost]
        public async Task<User> Login([FromQuery] string username, [FromQuery] string password)
        {
            // TODO:
            // 1. Grab password from JSON body
            // 2. Grab hash from database
            // 3. Extract salt from the hash stored in the database
            // 4. Concatentate this salt with the provided password
            // 5. Apply hashing algo to this string
            // 6. Concatenate the salt to this new hash
            // 7. Compare this new hash to the one stored in database
            // 8. Return true or false

            User currentUser = await _userRepository.GetUserByUsernameAsync(username);

            bool isValidCredentials = BCrypt.Net.BCrypt.Verify(password, currentUser.Password);

            if (isValidCredentials)
            {
                return currentUser;
            } else
            {
                return null;
            }
        }



        /// <summary>
        /// Signs up a user with a new username and password
        /// 1. Takes username and checks if it exists in database already
        /// 2. If user does not exist, then CREATE new user in "users" table with username, password, and UUID
        /// 3. Redirect to /login on frontend
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        [Route("signup")]
        [HttpPost]
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
            // login method
            // 1. Check if user exists in the database
                // use repository method to grab user by username (SELECT username FROM users WHERE username = username)
            // 2. Return JWT if username and password match
            
            // if user exists, then make sure the password matches database
                // SELECT password FROM USERS where username = username
                // if username = username_query then log user in