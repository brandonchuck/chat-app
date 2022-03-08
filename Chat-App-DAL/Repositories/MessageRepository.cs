using Chat_App_DAL.Interfaces;
using Chat_App_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_App_DAL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        ChatAppDbContext _chatAppDbContext;

        public MessageRepository(ChatAppDbContext chatAppDbContext)
        {
            _chatAppDbContext = chatAppDbContext;
        }

        public async Task<List<Message>> GetUserMessagesByIdAsync(int user_id)
        {
            return await _chatAppDbContext.Messages.Where(m => m.User.UserId == user_id).ToListAsync();
        }

        public async Task<Message> CreateChannelMessageAsync(string channelName, int userId, string text)
        {
            // Message can belong to only 1 Channel
            // Channel can have many Messages

            Message newMessage = new Message
            {
                Text = text,
            };
            _chatAppDbContext.Add(newMessage);
            await _chatAppDbContext.SaveChangesAsync();
            return newMessage;
        }
    }
}
