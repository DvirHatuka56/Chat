using Chat.Client.Requests;

namespace Chat.Client.RequestHandler
{
    public interface IRequestHandler
    {
        void Handle(ChatClient client);
    }
}