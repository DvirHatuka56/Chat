using System;
using Chat.Client.Requests;
using Chat.Client.Responses;

namespace Chat.Client.ResponseHandlers
{
    public class LoginHandler : IResponseHandler
    {
        public void Handle(ChatClient client, ResponseData response)
        {
            LoginResponse loginResponse = new LoginResponse(response.Key, response.Raw);
            client.User.Id = loginResponse.Id;
            client.User.Name = loginResponse.Name;

            Console.WriteLine("Logged in successfully");
        }
    }
}