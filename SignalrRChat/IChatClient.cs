using System.Threading.Tasks;
using static SignalrRChat.ChatHub;

namespace SignalrRChat.Api
{
    public interface IChatClient
    {
        Task ReceiveMessage(ChatMessage message);
    }
}
