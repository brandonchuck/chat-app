using Chat_App_DAL.Interfaces;
using Chat_App_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat_App_DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ChatAppDbContext _chatAppDbContext; // db context to interact with database
        public UserRepository(ChatAppDbContext chatAppDbContext)
        {
            _chatAppDbContext = chatAppDbContext;
        }

        // Create new User in table
        public async Task<User> CreateNewUserAsync(User user)
        {
            _chatAppDbContext.Users.Add(user); // add user to DbSet inside of the DbContext
            await _chatAppDbContext.SaveChangesAsync(); // apply changes to the database
            return user; // return the user that was added -- just for testing purposes for now
        }

        // Get all User's in table
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _chatAppDbContext.Users.ToListAsync(); // return a list of all User objects within DbSet
        }

        // Get User by user_id
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _chatAppDbContext.Users.FirstOrDefaultAsync(user => user.UserId == id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _chatAppDbContext.Users.FirstOrDefaultAsync(user => user.Username == username);
        }

    }
}
