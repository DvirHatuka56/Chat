using System;
using ConsoleChatClient.Requests;
using ConsoleChatClient.Responses;

namespace ConsoleChatClient.ResponseHandlers
{
    public class ErrorHandler : IResponseHandler
    {
        public void Handle(ChatClient client, ResponseData response)
        {
            ErrorResponse errorResponse = new ErrorResponse(response.Key, response.Raw);
            RequestData requestData = client.WaitingRequests.Find(data => data.Key.Equals(response.Key));
            client.WaitingRequests.Remove(requestData);
            Console.WriteLine($"Error response on {requestData.Code} request, key {requestData.Key}.{Environment.NewLine}{errorResponse.Error}");
            client.Restart();
        }
    }
}