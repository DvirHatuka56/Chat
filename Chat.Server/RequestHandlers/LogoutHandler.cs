using Chat.Server.Models;
using Chat.Server.Responses;

namespace Chat.Server.RequestHandlers
{
    public class LogoutHandler : RequestHandler
    {
        public LogoutHandler(User user) : base(user)
        {
        }

        public override Response Handle(ChatServer server, Request request)
        {
            server.RemoveUser(User);
            return new SuccessResponse(request.RequestKey);
        }
    }
}