using System;
using System.Windows;
using Chat.Client.Requests;
using Chat.Client.ResponseHandlers;
using Chat.Client.Responses;

namespace Chat.Client.Desktop.ResponseHandlers
{
    public class ErrorHandler : IResponseHandler
    {
        public void Handle(ChatClient client, ResponseData response)
        {
            ErrorResponse errorResponse = new ErrorResponse(response.Key, response.Raw);
            RequestData requestData = client.WaitingRequests.Find(data => data.Key.Equals(response.Key));
            MessageBox.Show($"Error response on {requestData.Code} request, key {requestData.Key}.{Environment.NewLine}{errorResponse.Error}");
            client.Restart();
        }
    }
}