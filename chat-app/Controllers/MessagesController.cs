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

        [HttpGet]
        public ActionResult<List<Message>> GetUserMessagesById(Guid user_id)
        {
            var userMessages =  _messageRepository.GetUserMessagesByIdAsync(user_id);
            return Ok(userMessages);
        }  



    }
}
