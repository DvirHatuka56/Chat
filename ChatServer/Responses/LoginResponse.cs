using ChatServer.Models;

namespace ChatServer.Responses
{
    public class LoginResponse : Response
    {
        private User User { get; }

        public LoginResponse(string key, User user) : base(ResponseCode.LoginSuccess, key)
        {
            User = user;
        }

        public override string ToString()
        {
            string response = $"{Key.PadLeft(Constants.REQUEST_KEY_SEGMENT, '0')}{(int)Code}{User.Id.ToString().PadLeft(Constants.ID_SEGMNET, '0')}{User.Name}";
            return $"{response.Length.ToString().PadLeft(Constants.LENGTH_SEGMNET, '0')}{response}";
        }
    }
}