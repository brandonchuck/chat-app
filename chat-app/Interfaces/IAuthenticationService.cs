using Chat_App_DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace chat_app.Controllers
{
    public interface IAuthenticationService
    {
        public string GenerateToken(User user);
    }
}