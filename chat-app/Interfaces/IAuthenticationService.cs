using Chat_App_DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace chat_app.Controllers
{
    public interface IAuthenticationService
    {
        public string GenerateAuthToken(User user);
        public Task<User> AuthenticateUser(string username);
        public bool ValidatePassword(string formPassword, string dbPassword);

    }
}