using System;

namespace ChatServer
{
    internal class Program
    {
        public static void Main()
        {
            ChatServer server = new ChatServer();
            server.Start();
            string command;
            do
            {
                command = Console.ReadLine() ?? "";
                if (command.Equals("cls"))
                {
                    Console.Clear();
                }
            } while (!command.Equals("stop"));
            server.Close();
        }
    }
}