using System.Collections.Generic;
using ConsoleChatClient.Requests;

namespace ConsoleChatClient.RequestHandler
{
    public abstract class RequestManager
    {
        protected Dictionary<string, IRequestHandler> Handlers { get; set; }
        protected ChatClient Client { get; }

        protected RequestManager(ChatClient client)
        {
            Client = client;
        }

        public abstract void Manage();
    }
}