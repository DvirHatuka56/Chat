﻿using System;
using ChatClient.Requests;
using ChatClient.Responses;

namespace ChatClient.ResponseHandlers
{
    public class SuccessHandler : IResponseHandler
    {
        public void Handle(ChatClient client, ResponseData response)
        {
            SuccessResponse successResponse = new SuccessResponse(response.Key, response.Raw);
            
            Console.WriteLine($"Request {response.Key} succeeded");
            
            client.WaitingRequests.Remove(new RequestData
            {
                Key = successResponse.Key
            });
        }
    }
}