using System;
using Chat.Client.Requests;
using Chat.Client.Responses;

namespace Chat.Client.ResponseHandlers
{
    public class SuccessHandler : IResponseHandler
    {
        public void Handle(ChatClient client, ResponseData response)
        {
            Console.WriteLine($"Request {new SuccessResponse(response.Key, response.Raw).Key} succeeded");
        }
    }
}