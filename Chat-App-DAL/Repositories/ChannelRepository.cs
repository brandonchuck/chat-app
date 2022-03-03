using Chat_App_DAL.Interfaces;
using Chat_App_DAL.Models;
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
            //Channel channel = _chatAppDbContext.Channels.First(channel => channel.ChannelName == newChannel.ChannelName);
            _chatAppDbContext.Channels.Add(newChannel); // add new channel; for seeding database
            await _chatAppDbContext.SaveChangesAsync(); // save changes
            return newChannel; // return created channel for testing

        }

        public async Task<bool> ValidateChannel(Channel newChannel)
        {
            Channel channel = _chatAppDbContext.Channels.FirstOrDefault(c => c.ChannelName == newChannel.ChannelName);
            if(channel != null)
            {
                return false;
            }
            return true;
        }
    }
}
