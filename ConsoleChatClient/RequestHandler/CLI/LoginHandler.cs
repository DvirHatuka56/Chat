using System;
using ConsoleChatClient.Requests;

namespace ConsoleChatClient.RequestHandler.CLI
{
    public class LoginHandler : IRequestHandler
    {
        public void Handle(ChatClient client)
        {
            Console.Write("Enter id: ");
            int id = int.Parse(Console.ReadLine() ?? throw new ArgumentException());
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            LoginRequest request = new LoginRequest(ChatClient.GenerateKey(), id, password);
            client.SendRequest(request);
        }
    }
}