using System.Threading.Tasks;

namespace SignalrRChat.Api
{
    public interface IChatClient
    {
        Task ReceiveMessage(ChatMessage message);
    }
}
