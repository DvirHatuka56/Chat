using ChatServer.Models;
using ChatServer.Responses;

namespace ChatServer.RequestHandlers
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