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
        public Task<List<Message>> GetUserMessagesByIdAsync(Guid user_id);
    }
}
