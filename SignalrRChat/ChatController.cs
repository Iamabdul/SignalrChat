using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalrRChat.Api
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        readonly IHubContext<ChatHub, IChatClient> _chatHub;
        public ChatController(IHubContext<ChatHub, IChatClient> chatHub)
        {
            _chatHub = chatHub;
        }

        [HttpPost("messages")]
        public async Task Post(ChatMessage message)
        {
            Console.WriteLine($"Heeeeeey SendMessage executed with this message: user = {message.User}, message = {message.Message}");
            Console.WriteLine("Server: Preparing to execute ReceiveMessage...........................................");

            await _chatHub.Clients.All.ReceiveMessage(message);
        }
    }
}