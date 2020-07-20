using System;
using System.Collections.Generic;
using ConsoleChatClient.Models;
using Network.Client;

namespace ConsoleChatClient
{
    internal class Program
    {
        public static void Main()
        {
            SendTexts(new List<string>
            {
                "Hello",
                "How are you?",
                "Connect to Discord at 18:00"
            });
            Update();
        }

        private static void SendTexts(List<string> texts)
        {
            ChatClient client = new ChatClient();
            client.Login(2, "1234", out _);
            foreach (string text in texts)
            {
                OutgoingMessage outgoingMessage = new OutgoingMessage(client.User.Id, 3339, new List<int> {3}){Content = text};
                client.SendText(outgoingMessage, out _);
            }
            client.Logout(out _);
        }

        private static void Update()
        {
            ChatClient client = new ChatClient();
            client.Login(3, "5678", out _);
            List<IncomingMessage> messages = client.Update(new List<int> {3339}, out _);
            client.Logout(out _);
            foreach (IncomingMessage message in messages)
            {
                Console.WriteLine(message.ToString());
            }
        }
    }
}