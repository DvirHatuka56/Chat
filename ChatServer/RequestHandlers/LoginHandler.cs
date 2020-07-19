using ChatServer.Database;
using ChatServer.Models;
using ChatServer.Responses;

namespace ChatServer.RequestHandlers
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
            int id = User.Client.ReceiveInt(Constants.ID_SEGMNET);
            if (!Manager.UserExists(id)) { return new ErrorResponse(new UserNotFoundException());}

            string password = User.Client.ReceiveString(request.Length - Constants.ID_SEGMNET);
            if (!password.Equals(Manager.GetHashedPassword(id)))
            {
                return new ErrorResponse(new WrongPasswordException());
            }

            User.Id = id;
            User.Name = Manager.GetName(id);
            server.AddUser(User);
            return new LoginResponse(User);
        }
    }
}