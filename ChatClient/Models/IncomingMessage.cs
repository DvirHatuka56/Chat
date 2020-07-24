using System;
using System.Collections.Generic;

namespace ChatClient.Models
{
    public class IncomingMessage
    {
        public int SenderId { get; }
        public int ChatId { get; }
        public DateTime Time { get; }
        public object Content { get; set; }
        public Type ContentType => Content.GetType();

        public IncomingMessage(int senderId, int chatId, DateTime time)
        {
            SenderId = senderId;
            ChatId = chatId;
            Time = time;
        }

        public override string ToString()
        {
            return 
                $"{SenderId} sent {Content} at {Time} in {ChatId}";
        }
    }
}