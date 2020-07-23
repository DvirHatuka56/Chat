﻿using System.Text;
using ChatServer.Models;

namespace ChatServer.Responses
{
    public class NewTextResponse : Response
    {
        private Message Message { get; }
        
        public NewTextResponse(Message message) : base(ResponseCode.NewMessage)
        {
            Message = message;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append((int) Code);
            builder.Append(Message.ChatId.ToString().PadLeft(Constants.CHAT_SEGMNET, '0'));
            builder.Append(Message.SenderId.ToString().PadLeft(Constants.ID_SEGMNET, '0'));
            builder.Append(Message.Time.ToString("ddMMyyyyhhmmsstt")); // 19072020125403 => 19.7.2020 12:54:03
            builder.Append(Message.Content);
            return $"{builder.Length.ToString().PadLeft(Constants.LENGTH_SEGMNET, '0')}{builder}";
        }
    }
}