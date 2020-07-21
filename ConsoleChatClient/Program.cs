using System;
using System.Collections.Generic;
using System.Threading;
using ConsoleChatClient.Models;

namespace ConsoleChatClient
{
    internal class Program
    {
        private static bool _run;

        private static bool Run
        {
            get => _run;
            set 
            {
                Console.WriteLine($"Live update {(value ? "enabled" : "disabled")}");
                _run = value;
            }
        }

        public static void Main()
        {
            ChatClient client = new ChatClient();
            ChatClient second = new ChatClient();
            client.Login(3, "5678", out _);
            second.Login(2, "1234", out _);
            Run = true;
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    if (Run)
                    {
                        try
                        {
                            LiveUpdate(client);
                        }
                        catch (Exception)
                        {
                            return;
                        }
                    }
                }
            });
            thread.Start();
            string command = "";
            while (!command.Equals("stop"))
            {
                command = Console.ReadLine();
                command = command ?? string.Empty;
                if (command.Equals("pause"))
                {
                    Run = !Run;
                }
                else if (command.Equals("update"))
                {
                    bool prev = Run;
                    Run = false;
                    Update(client);
                    Run = prev;
                }
            }
            thread.Abort();
            client.Logout(out _);
            second.Logout(out _);
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

        private static void Update(ChatClient client)
        {
            List<IncomingMessage> messages = client.Update(new List<int> {1111}, out _);
            foreach (IncomingMessage message in messages)
            {
                Console.WriteLine(message.ToString());
            }
        }
        
        private static void LiveUpdate(ChatClient client)
        {
            if (!Run) return;
            IncomingMessage[] messages = client.LiveUpdate(out _);
            for (var i = 0; i < messages.Length; i++)
            {
                Console.WriteLine(messages[i]);
            }
        }
    }
}