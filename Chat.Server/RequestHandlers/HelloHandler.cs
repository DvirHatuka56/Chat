using Chat.Server.Models;
using Chat.Server.Responses;

namespace Chat.Server.RequestHandlers
{
    public class HelloHandler : RequestHandler
    {
        public HelloHandler(User user) : base(user)
        {
        }

        public override Response Handle(ChatServer server, Request request)
        {
            return new SuccessResponse(request.RequestKey);
        }
    }
}