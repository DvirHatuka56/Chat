using ConsoleChatClient.Responses;

namespace ConsoleChatClient.ResponseHandlers
{
    public interface IResponseHandler
    {
        void Handle(ChatClient client, ResponseData response);
    }
}