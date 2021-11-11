using Microsoft.AspNetCore.SignalR;
using SignalrRChat.Api;

namespace SignalrRChat
{
    public  class ChatHub : Hub<IChatClient>
    {    
    }

    public class ChatMessage
    {
        public string User { get; set; }

        public string Message { get; set; }
    }
}