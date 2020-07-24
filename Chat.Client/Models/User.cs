using System.Collections.Generic;

namespace Chat.Client.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<int, Chat> Chats { get; set; }

        public User()
        {
            Chats = new Dictionary<int, Chat>();
        }
        
        public override string ToString()
        {
            return $"{Name} #{Id}";
        }
    }
}