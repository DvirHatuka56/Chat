using Chat.Server.Models;

namespace Chat.Server.Responses
{
    public class RegisterResponse : Response
    {
        private User User { get; }

        public RegisterResponse(string key, User user) : base(ResponseCode.Success, key)
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