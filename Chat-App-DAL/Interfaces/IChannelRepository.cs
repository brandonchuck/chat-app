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
        public Task<List<Message>> GetMessagesByChannelName(string channelName);

    }
}
