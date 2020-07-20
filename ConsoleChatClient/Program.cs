using System.Collections.Generic;
using ConsoleChatClient.Models;

namespace ConsoleChatClient
{
    internal class Program
    {
        public static void Main()
        {
            ChatClient client = new ChatClient();
            client.Login(2, "1234", out _);
            client.Hello(out _);
            OutgoingMessage outgoingMessage = new OutgoingMessage(client.User.Id, 3339, new List<int> {3}){Content = "Hello"};
            client.SendText(outgoingMessage, out _);
            client.Logout(out _);
        }
    }
}