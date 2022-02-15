using Microsoft.AspNetCore.Mvc;

namespace chat_app.Controllers
{

    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
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
        [HttpPost]
        public void Login([FromBody] string username, [FromBody] string password)
        {
            // 1. Check if user exists in the database
                // use repository method to grab user by username (SELECT username FROM users WHERE username = username)
            // 2. Return JWT if username and password match
            
            // if user exists, then make sure the password matches database
                // SELECT password FROM USERS where username = username
                // if username = username_query then log user in
        }



        /// <summary>
        /// Signs up a user with a new username and password
        /// 1. Takes username and checks if it exists in database already
        /// 2. If user does not exist, then CREATE new user in "users" table with username, password, and UUID
        /// 3. Redirect to /login on frontend
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        [HttpPost]
        public void Signup([FromBody] string username, [FromBody] string password)
        {

        }


    }
}
