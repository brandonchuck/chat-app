using chat_app.Hubs;
using Chat_App_DAL.DTOs;
using Chat_App_DAL.Interfaces;
using Chat_App_DAL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

namespace chat_app.Controllers
{
    [Route("api/messages")]
    [ApiController]
    [Authorize]
    public class MessagesController : ControllerBase
    {
        IMessageRepository _messageRepository;
        IHubContext<MessageHub> _messageHub;

        public MessagesController(IMessageRepository messageRepository, IHubContext<MessageHub> messageHub)
        {
            _messageRepository = messageRepository;
            _messageHub = messageHub;
        }

        // Get Messages by Id -- not used yet
        [HttpGet("{userId}")]
        public async Task<ActionResult<List<Message>>> GetUserMessagesByIdAsync([FromRoute] int userId)
        {
            var userMessages = await _messageRepository.GetUserMessagesByIdAsync(userId);
            return Ok(userMessages);
        }


        // Create new message in channel
        [HttpPost("{channelName}/create")]
        public async Task<ActionResult<string>> CreateMessage([FromRoute] string channelName, [FromBody] NewMessageDTO newMessageDTO)
        {
            // get token from Authorization header
            var authHeader = Request.Headers[HeaderNames.Authorization];
            var authToken = HttpContext.GetTokenAsync("token"); // this will grab the token from AuthenticationProperties

            if (String.IsNullOrEmpty(authHeader))
            {
                return Unauthorized("You must be authenticated");
            }

            if (AuthenticationHeaderValue.TryParse(authHeader, out var headerValue))
            {
                var scheme = headerValue.Scheme; // "Bearer" prefix
                var jwt = headerValue.Parameter; // token

                // get userId from token payload
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = tokenHandler.ReadJwtToken(jwt);
                var userId = jwtSecurityToken.Claims.Where(c => c.Type == "Id")
                    .Select(c => c.Value).FirstOrDefault();

                // pass user_id from JWT, channelName from route, and text from MessageDTO
                if (userId == null)
                {
                    return NotFound("User not found");
                }
                
                await _messageRepository.CreateChannelMessageAsync(newMessageDTO.Text, int.Parse(userId), channelName);
            }
            

            // send new message to all other clients connected to websocket
            await _messageHub.Clients.All.SendAsync("SendMessage", newMessageDTO.Text);

            return Ok("Message created!");
        }
    }
}
