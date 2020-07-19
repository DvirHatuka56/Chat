using ChatServer.Database;
using ChatServer.Models;
using ChatServer.Responses;

namespace ChatServer.RequestHandlers
{
    public class RegisterHandler : RequestHandler
    {
        private DatabaseManager Manager { get; }
        
        public RegisterHandler(User user) : base(user)
        {
            Manager = new DatabaseManager(Constants.GetConnectionString());
        }

        public override Response Handle(ChatServer server, Request request)
        {
            int nameLength = User.Client.ReceiveInt(Constants.NAME_LENGTH_SEGMENT);
            string name = User.Client.ReceiveString(nameLength);
            string password = User.Client.ReceiveString(request.Length - Constants.NAME_LENGTH_SEGMENT - nameLength);
            if (!Manager.Register(name, password))
            {
                return new ErrorResponse(new UserAlreadyExistsException());
            }

            User.Id = Manager.GetId(name);
            User.Name = name;
            server.AddUser(User);
            return new RegisterResponse(User);
        }
    }
}