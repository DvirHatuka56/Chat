using Chat.Server.Database;
using Chat.Server.Models;
using Chat.Server.Responses;

namespace Chat.Server.RequestHandlers
{
    public class LoginHandler : RequestHandler
    {
        private DatabaseManager Manager { get; }
        
        public LoginHandler(User user) : base(user)
        {
            Manager = new DatabaseManager(Constants.GetConnectionString());
        }

        public override Response Handle(ChatServer server, Request request)
        {
            RequestParser parser = new RequestParser(request.RawRequest, Constants.CODE_SEGMNET);
            int id = parser.GetInt(Constants.ID_SEGMNET);
            if (!Manager.UserExists(id)) { return new ErrorResponse(request.RequestKey, new UserNotFoundException());}

            string password = parser.Get();
            if (!password.Equals(Manager.GetHashedPassword(id)))
            {
                return new ErrorResponse(request.RequestKey, new WrongPasswordException());
            }

            User.Id = id;
            User.Name = Manager.GetName(id);
            server.AddUser(User);
            return new LoginResponse(request.RequestKey, User);
        }
    }
}