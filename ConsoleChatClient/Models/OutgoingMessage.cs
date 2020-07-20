using System;
using System.Collections.Generic;

namespace ConsoleChatClient.Models
{
    public class OutgoingMessage
    {
        public int SenderId { get; }
        public int ChatId { get; }
        public object Content { get; set; }
        public List<int> Recipients { get; }
        public Type ContentType => Content.GetType();

        public OutgoingMessage(int senderId, int chatId, List<int> recipients)
        {
            SenderId = senderId;
            ChatId = chatId;
            Recipients = recipients;
        }
    }
}