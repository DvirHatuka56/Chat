using System.Collections.Generic;

namespace ConsoleChatClient.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Chat> Chats { get; set; }

        public override string ToString()
        {
            return $"{Name} #{Id}";
        }
    }
}