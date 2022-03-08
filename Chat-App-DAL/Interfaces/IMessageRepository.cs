using Chat_App_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_App_DAL.Interfaces
{
    public interface IMessageRepository
    {
        public Task<List<Message>> GetUserMessagesByIdAsync(int user_id);
        public Task<Message> CreateChannelMessageAsync(string channelName, int userId, string text);
        //public Task<Message> CreateChannelMessage(Message message);
    }
}
