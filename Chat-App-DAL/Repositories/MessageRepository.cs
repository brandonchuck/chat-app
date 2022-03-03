﻿using Chat_App_DAL.Interfaces;
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

        public async Task<List<Message>> GetUserMessagesByIdAsync(Guid user_id)
        {
            return await _chatAppDbContext.Messages.Where(m => m.User.UserId == user_id).ToListAsync();
        }

        //public async Task<Message> CreateChannelMessage(string channelName)
        //{

        //}
    }
}
