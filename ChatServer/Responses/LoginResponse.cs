using ChatServer.Models;

namespace ChatServer.Responses
{
    public class LoginResponse : Response
    {
        private User User { get; }

        public LoginResponse(User user) : base(ResponseCode.Success)
        {
            User = user;
        }

        public override string ToString()
        {
            string response = $"{(int)Code}{User.Id.ToString().PadLeft(Constants.ID_SEGMNET, '0')}{User.Name}";
            return $"{response.Length.ToString().PadLeft(Constants.LENGTH_SEGMNET, '0')}{response}";
        }
    }
}