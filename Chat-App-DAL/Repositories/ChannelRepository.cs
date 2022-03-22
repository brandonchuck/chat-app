using Chat_App_DAL.DTOs;
using Chat_App_DAL.Interfaces;
using Chat_App_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat_App_DAL.Repositories
{
    public class ChannelRepository : IChannelRepository
    {
        ChatAppDbContext _chatAppDbContext;

        public ChannelRepository(ChatAppDbContext chatAppDbContext)
        {
            _chatAppDbContext = chatAppDbContext;
        }


        public async Task<Channel> CreateChannelAsync(Channel newChannel)
        {
            // check if channel exists already
            _chatAppDbContext.Channels.Add(newChannel); // add new channel; for seeding database
            await _chatAppDbContext.SaveChangesAsync(); // save changes
            return newChannel; // return created channel for testing
        }

        public async Task<bool> ValidateChannelAsync(Channel newChannel)
        {
            Channel channel = await _chatAppDbContext.Channels.FirstOrDefaultAsync(c => c.ChannelName == newChannel.ChannelName);
            if(channel != null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<MessageDTO>> GetMessagesByChannelNameAsync(string channelName)
        {
            List<MessageDTO> channelMessages = await
                (
                    from message in _chatAppDbContext.Messages
                    join channel in _chatAppDbContext.Channels on message.Channel.ChannelId equals channel.ChannelId
                    join user in _chatAppDbContext.Users on message.User.UserId equals user.UserId
                    where channel.ChannelName == channelName
                    select new MessageDTO
                    {
                        Text = message.Text,
                        Username = user.Username,
                        CreatedAt = message.CreatedAt
                    } 
                ).ToListAsync();

            return channelMessages;
        }
    
        public async Task<int> GetChannelIdByChannelNameAsync(string channelName)
        {
            Channel channel = await _chatAppDbContext.Channels.FirstOrDefaultAsync(c => c.ChannelName == channelName);
            return channel.ChannelId;
        }

        public async Task<List<ChannelDTO>> GetChannelsAsync()
        {
            List<ChannelDTO> channels = await 
                (
                    from channel in _chatAppDbContext.Channels
                    select new ChannelDTO
                    {
                        ChannelName = channel.ChannelName,
                    }
                ).ToListAsync();

            return channels;
        }
    }


}