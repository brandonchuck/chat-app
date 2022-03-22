using Chat_App_DAL.DTOs;
using Chat_App_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_App_DAL.Interfaces
{
    public interface IChannelRepository
    {
        public Task<Channel> CreateChannelAsync(Channel channel);
        public Task<bool> ValidateChannelAsync(Channel newChannel);
        public Task<List<MessageDTO>> GetMessagesByChannelNameAsync(string channelName);
        public Task<int> GetChannelIdByChannelNameAsync(string channelName);
        public Task<List<ChannelDTO>> GetChannelsAsync();

    }
}
