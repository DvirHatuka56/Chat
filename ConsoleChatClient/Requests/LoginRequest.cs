using ChatServer;

namespace ConsoleChatClient.Requests
{
    public class LoginRequest : Request
    {
        private int Id { get; }
        private string Password { get; }

        public LoginRequest(int id, string password)
        {
            Code = RequestCode.Login;
            Id = id;
            Password = password;
        }
        
        public override string ToString()
        {
            string request = $"{(int)Code}{Id.ToString().PadLeft(Constants.ID_SEGMNET, '0')}{Password}";
            return $"{request.Length.ToString().PadLeft(Constants.ID_SEGMNET, '0')}{request}";
        }
    }
}