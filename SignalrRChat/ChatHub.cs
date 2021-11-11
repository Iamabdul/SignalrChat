using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalrRChat.Api;

namespace SignalrRChat
{
    public  class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(ChatMessage message)
        {
            Console.WriteLine($"Heeeeeey SendMessage executed with this message: user = {message.User}, message = {message.Message}");
            Console.WriteLine("Server: Preparing to execute ReceiveMessage...........................................");
            await Clients.All.ReceiveMessage(message);
        }

        public class ChatMessage
        {
            public string User { get; set; }

            public string Message { get; set; }
        }
    }
}