using System;
using System.Collections.Generic;
using Chat.Client.Models;
using Chat.Client.Requests;

namespace Chat.Client.RequestHandler.CLI
{
    public class SendTextHandler : IRequestHandler
    {
        public void Handle(ChatClient client)
        {
            Console.Write("Enter chat id:");
            int id = int.Parse(Console.ReadLine() ?? throw new ArgumentException());
            Console.Write("Enter message: ");
            SendTextRequest request = new SendTextRequest(ChatClient.GenerateKey(), new OutgoingMessage(client.User.Id, id, 
                new List<int>{1, 2})
            {
                Content = Console.ReadLine()
            });
            client.SendRequest(request);
        }
    }
}