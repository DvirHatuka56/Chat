﻿using System;
using ChatClient.Requests;
using ChatClient.Responses;

namespace ChatClient.ResponseHandlers
{
    public class LoginHandler : IResponseHandler
    {
        public void Handle(ChatClient client, ResponseData response)
        {
            LoginResponse loginResponse = new LoginResponse(response.Key, response.Raw);
            client.User.Id = loginResponse.Id;
            client.User.Name = loginResponse.Name;

            Console.WriteLine("Logged in successfully");
            
            client.WaitingRequests.Remove(new RequestData
            {
                Key = loginResponse.Key
            });
        }
    }
}