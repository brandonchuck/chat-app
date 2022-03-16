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
        public Task<Channel> CreateChannel(Channel channel);
        public Task<bool> ValidateChannel(Channel newChannel);
        public Task<List<MessageDTO>> GetMessagesByChannelName(string channelName);
        public Task<int> GetChannelIdByChannelName(string channelName);
    }
}
