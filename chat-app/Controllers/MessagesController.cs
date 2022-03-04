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
        public async Task<ActionResult<List<Message>>> GetUserMessagesById([FromRoute] int userId)
        {
            var userMessages = await _messageRepository.GetUserMessagesByIdAsync(userId);
            return Ok(userMessages);
        }

        //[HttpPost("{channelName}/create")]
        //public async Task<ActionResult<string>> CreateMessage([FromRoute] string channelName, [FromHeader] int userId, [FromBody] string text)
        //{
        //    var message = await _messageRepository.CreateChannelMessage(channelName, userId, text);
        //    return Ok(message);
        //}
    }
}
