using ChatClient.Requests;

namespace ChatClient.RequestHandler
{
    public interface IRequestHandler
    {
        void Handle(ChatClient client);
    }
}