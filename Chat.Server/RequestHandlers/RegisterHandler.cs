using Chat.Server.Database;
using Chat.Server.Models;
using Chat.Server.Responses;

namespace Chat.Server.RequestHandlers
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
            RequestParser parser = new RequestParser(request.RawRequest, Constants.CODE_SEGMNET);
            int nameLength = parser.GetInt(Constants.NAME_LENGTH_SEGMENT);
            string name = parser.Get(nameLength);
            string password = parser.Get();
            if (!Manager.Register(name, password))
            {
                return new ErrorResponse(request.RequestKey, new UserAlreadyExistsException());
            }

            User.Id = Manager.GetId(name);
            User.Name = name;
            server.AddUser(User);
            return new RegisterResponse(request.RequestKey, User);
        }
    }
}