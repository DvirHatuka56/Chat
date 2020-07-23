using ConsoleChatClient.Requests;

namespace ConsoleChatClient.RequestHandler
{
    public interface IRequestHandler
    {
        void Handle(ChatClient client);
    }
}