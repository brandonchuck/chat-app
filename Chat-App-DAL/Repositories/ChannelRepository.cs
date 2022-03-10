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
    public class ChannelRepository : IChannelRepository
    {
        ChatAppDbContext _chatAppDbContext;

        public ChannelRepository(ChatAppDbContext chatAppDbContext)
        {
            _chatAppDbContext = chatAppDbContext;
        }


        public async Task<Channel> CreateChannel(Channel newChannel)
        {
            // check if channel exists already
            _chatAppDbContext.Channels.Add(newChannel); // add new channel; for seeding database
            await _chatAppDbContext.SaveChangesAsync(); // save changes
            return newChannel; // return created channel for testing
        }

        public async Task<bool> ValidateChannel(Channel newChannel)
        {
            Channel channel = await _chatAppDbContext.Channels.FirstOrDefaultAsync(c => c.ChannelName == newChannel.ChannelName);
            if(channel != null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<MessageDTO>> GetMessagesByChannelName(string channelName)
        {
            List<MessageDTO> channelMessages = await
                (
                    from message in _chatAppDbContext.Messages
                    join channel in _chatAppDbContext.Channels on message.Channel.ChannelId equals channel.ChannelId
                    where channel.ChannelName == channelName
                    select new MessageDTO
                    {
                        Text = message.Text
                    } 
                ).ToListAsync();

            return channelMessages;
        }
    
        public async Task<int> GetChannelIdByChannelName(string channelName)
        {
            Channel channel = await _chatAppDbContext.Channels.FirstOrDefaultAsync(c => c.ChannelName == channelName);
            return channel.ChannelId;
        }
    }


}