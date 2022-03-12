using Chat_App_DAL.Models;

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
