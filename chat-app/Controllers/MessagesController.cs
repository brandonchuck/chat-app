using Chat_App_DAL.DTOs;
using Chat_App_DAL.Interfaces;
using Chat_App_DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace chat_app.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<Message>>> GetUserMessagesByIdAsync([FromRoute] int userId)
        {
            var userMessages = await _messageRepository.GetUserMessagesByIdAsync(userId);
            return Ok(userMessages);
        }

        [HttpPost("{channelName}/create")]
        public async Task<ActionResult<string>> CreateMessage([FromRoute] string channelName, [FromHeader] int userId, [FromBody] MessageDTO messageDTO)
        {

            var message = await _messageRepository.CreateChannelMessageAsync(channelName, userId, messageDTO.Text);
            return Ok(message);
        }
    }
}
