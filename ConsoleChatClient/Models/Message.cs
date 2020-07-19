using System;

namespace ConsoleChatClient.Models
{
    public class Message
    {
        public int SenderId { get; }
        public DateTime Time { get; }
        public int ChatId { get; }
        public object Content { get; set; }
        public Type ContentType => Content.GetType();

        public Message(int senderId, DateTime time, int chatId)
        {
            SenderId = senderId;
            Time = time;
            ChatId = chatId;
        }
    }
}