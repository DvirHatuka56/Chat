using Chat.Server.Models;
using Chat.Server.Responses;

namespace Chat.Server.RequestHandlers
{
    public abstract class RequestHandler
    {
        protected User User { get; }

        protected RequestHandler(User user)
        {
            User = user;
        }

        public abstract Response Handle(ChatServer server, Request request);

    }
}