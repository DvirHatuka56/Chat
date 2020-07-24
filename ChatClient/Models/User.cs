﻿using System.Collections.Generic;

namespace ChatClient.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<int, Chat> Chats { get; set; }

        public override string ToString()
        {
            return $"{Name} #{Id}";
        }
    }
}