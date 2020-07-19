using ChatServer.Models;
using ChatServer.Responses;

namespace ChatServer.RequestHandlers
{
    public class LogoutHandler : RequestHandler
    {
        public LogoutHandler(User user) : base(user)
        {
        }

        public override Response Handle(ChatServer server, Request request)
        {
            server.RemoveUser(User);
            User.Client.Close();
            return new SuccessResponse();
        }
    }
}