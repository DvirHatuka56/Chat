﻿using System;
using System.Globalization;
using ConsoleChatClient.Models;

namespace ConsoleChatClient.Responses
{
    public class NewTextResponse : Response
    {
        public IncomingMessage IncomingMessage { get; set; }
        
        public NewTextResponse(string response) : base(ResponseCode.NewMessage, response)
        {
            Deserialize(response);
        }

        protected sealed override void Deserialize(string response)
        {
            if (!response.StartsWith(((int) Code).ToString()))
            {
                throw new FormatException($"The given response is not new text response: {response}");
            }
            
            int i = Constants.CODE_SEGMNET;
            
            int chatId = int.Parse(response.Substring(i, Constants.CHAT_SEGMNET));
            i += Constants.CHAT_SEGMNET;
            
            int senderId = int.Parse(response.Substring(i, Constants.ID_SEGMNET));
            i += Constants.ID_SEGMNET;

            string substring = response.Substring(i, Constants.TIME_SEGMENT);
            DateTime time = DateTime.ParseExact(substring, "ddMMyyyyhhmmsstt", null);
            i += Constants.TIME_SEGMENT;

            string content = response.Substring(i);
            
            IncomingMessage = new IncomingMessage(senderId, chatId, time)
            {
                Content = content
            };
        }
    }
}