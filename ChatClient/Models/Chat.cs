using System.Collections.Generic;

namespace ChatClient.Models
{
    public class Chat
    {
        public int Id { get; }
        public List<User> Users { get; }
        public List<IncomingMessage> Messages { get; }

        public Chat(int id)
        {
            Id = id;
            Users = new List<User>();
            Messages = new List<IncomingMessage>();
        }
    }
}