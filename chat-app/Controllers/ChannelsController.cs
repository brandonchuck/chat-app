using Chat_App_DAL.DTOs;
using Chat_App_DAL.Interfaces;
using Chat_App_DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace chat_app.Controllers
{
    [Route("api/channel")]
    [Authorize] // only allow access to authenticated users
    [ApiController]
    public class ChannelsController : ControllerBase
    {
        private readonly IChannelRepository _channelRepository;
        public ChannelsController(IChannelRepository channelRepository)
        {
            _channelRepository = channelRepository;
        }

        // Create new channel
        [HttpPost("create")]
        public async Task<ActionResult<Channel>> CreateNewChannelAsync([FromBody] ChannelDTO channelDTO)
        {
            Channel channel = new Channel
            {
                ChannelName = channelDTO.ChannelName
            };

            bool isValidChannel = await _channelRepository.ValidateChannelAsync(channel);

            if (!isValidChannel)
            {
                return BadRequest("Channel already exists");
            }

            Channel newChannel = await _channelRepository.CreateChannelAsync(channel);
            return Ok(newChannel);
        }

       
        // Get messages from every user in a channel
        [HttpGet("{channelName}/messages")]
        public async Task<ActionResult<List<MessageDTO>>> GetChannelMessagesAsync([FromRoute] string channelName)
        {
            List<MessageDTO> channelMessages = await _channelRepository.GetMessagesByChannelNameAsync(channelName);
            if (channelMessages == null)
            {
                return NoContent();
            }
            return Ok(channelMessages);
        }

        [HttpGet("channels")]
        public async Task<ActionResult<List<ChannelDTO>>> GetChannelsAsync()
        {
            List<ChannelDTO> channels = await _channelRepository.GetChannelsAsync();
            if (channels == null)
            {
                return NoContent();
            }
            return Ok(channels);
        }
    }
}
