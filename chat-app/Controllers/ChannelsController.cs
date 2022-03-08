﻿using Chat_App_DAL.DTOs;
using Chat_App_DAL.Interfaces;
using Chat_App_DAL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chat_app.Controllers
{
    [Route("api/channel")]
    [ApiController]
    [Authorize]
    public class ChannelsController : ControllerBase
    {
        private readonly IChannelRepository _channelRepository;
        public ChannelsController(IChannelRepository channelRepository)
        {
            _channelRepository = channelRepository;
        }

        [HttpPost("new-channel")]
        public async Task<ActionResult<Channel>> CreateNewChannelAsync([FromBody] ChannelDTO channelDTO)
        {
            Channel channel = new Channel
            {
                ChannelName = channelDTO.ChannelName
            };

            bool isValidChannel = await _channelRepository.ValidateChannel(channel);

            if (!isValidChannel)
            {
                return BadRequest("Channel already exists");
            }

            Channel newChannel = await _channelRepository.CreateChannel(channel);
            return Ok(newChannel);
        }


        // get messages from every user in a channel
        [HttpGet("{channelName}/messages")]
        public async Task<ActionResult<List<Message>>> GetChannelMessagesAsync([FromRoute] string channelName)
        {
            List<Message> channelMessages = await _channelRepository.GetMessagesByChannelName(channelName);
            return Ok(channelMessages);
        }

    }
}
