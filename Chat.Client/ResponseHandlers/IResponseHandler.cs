using Chat.Client.Responses;

namespace Chat.Client.ResponseHandlers
{
    public interface IResponseHandler
    {
        void Handle(ChatClient client, ResponseData response);
    }
}