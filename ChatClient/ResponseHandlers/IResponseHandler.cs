using ChatClient.Responses;

namespace ChatClient.ResponseHandlers
{
    public interface IResponseHandler
    {
        void Handle(ChatClient client, ResponseData response);
    }
}