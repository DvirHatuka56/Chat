using System.Collections.Generic;

namespace Chat.Client.Models
{
    public class Chat
    {
        public int Id { get; }
        public string Name { get; set; }
        public List<int> Members { get; }
        public List<IncomingMessage> Messages { get; }

        public Chat(int id)
        {
            Id = id;
            Members = new List<int>();
            Messages = new List<IncomingMessage>();
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}