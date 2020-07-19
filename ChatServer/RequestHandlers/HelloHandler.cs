using ChatServer.Models;
using ChatServer.Responses;

namespace ChatServer.RequestHandlers
{
    public class HelloHandler : RequestHandler
    {
        public HelloHandler(User user) : base(user)
        {
        }

        public override Response Handle(ChatServer server, Request request)
        {
            return new SuccessResponse();
        }
    }
}