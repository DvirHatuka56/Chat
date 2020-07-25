using Chat.Client.Responses;

namespace Chat.Client.ResponseHandlers
{
    public class RegisterHandler : IResponseHandler
    {
        public void Handle(ChatClient client, ResponseData response)
        {
            RegisterResponse registerResponse = new RegisterResponse(response.Code, response.Key, response.Raw);
            client.User.Id = registerResponse.Id;
            client.User.Name = registerResponse.Name;
        }
    }
}