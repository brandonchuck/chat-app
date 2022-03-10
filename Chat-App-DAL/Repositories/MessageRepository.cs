using Chat_App_DAL.DTOs;
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

        public async Task<Message> CreateChannelMessageAsync(string text, int userId, string channelName)
        {
            // Message can belong to only 1 Channel
            // Channel can have many Messages

            int channelId = _chatAppDbContext.Channels.First(c => c.ChannelName == channelName).ChannelId;


            // *** Trying to create new Message object and save to database
            // *** Trying to pass text, user_id (from jwt) and channel_name (from Route) to create Message object
            Message newMessage = new Message
            {
                Text = text,
                // User.UserId = userId;
                // Channel.ChannelId = channelId;
            };

            _chatAppDbContext.Add(newMessage);
            await _chatAppDbContext.SaveChangesAsync();
            return newMessage;
        }
    }
}
