using Microsoft.AspNetCore.Mvc;

namespace chat_app.Controllers
{
    public class ChatroomController : ControllerBase
    {

        // get all messages from single user
        [HttpGet]
        public void GetUserMessages(string token)
        {

        }

        // get messages from every user in a chatroom
        [HttpGet]
        public void GetChatroomMessages(string token)
        {

        }

    }
}
