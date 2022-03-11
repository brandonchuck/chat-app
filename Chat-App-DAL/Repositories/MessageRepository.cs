using Chat_App_DAL.DTOs;
using Chat_App_DAL.Interfaces;
using Chat_App_DAL.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task CreateChannelMessageAsync(string text, int userId, string channelName)
        {
            Channel channel = await _chatAppDbContext.Channels.FirstOrDefaultAsync(c => c.ChannelName == channelName);
            int channelId = channel.ChannelId;

            Message newMessage = new Message
            {
                Text = text,
                user_id = userId,
                channel_id = channelId,
            };

            _chatAppDbContext.Messages.Add(newMessage);
            await _chatAppDbContext.SaveChangesAsync();
        }
    }
}
