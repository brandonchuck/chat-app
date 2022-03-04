using Chat_App_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_App_DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateNewUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUsernameAsync(string name);
        Task<List<User>> GetAllUsersAsync();
    }
}
