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
        public async Task<List<User>> Login([FromBody] User user)
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users;
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
        public async Task<User> Signup([FromBody] User user)
        {
            var newUser = await _userRepository.CreateNewUserAsync(user);
            return newUser;
            // 1. Pass username & password in JSON body
            // 2. Create the user in the database
            // 3. Confirm that user has been created

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