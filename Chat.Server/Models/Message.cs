using System;
using System.Collections.Generic;

namespace Chat.Server.Models
{
    public class Message
    {
        public int SenderId { get; }
        public DateTime Time { get; }
        public int ChatId { get; }
        public object Content { get; set; }
        public Type ContentType { get; set; }
        public List<int> Recipients { get; }

        public Message(int senderId, DateTime time, int chatId, List<int> recipients)
        {
            SenderId = senderId;
            Time = time;
            ChatId = chatId;
            Recipients = recipients;
        }
    }
}