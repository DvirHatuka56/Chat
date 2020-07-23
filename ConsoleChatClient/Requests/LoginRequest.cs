namespace ConsoleChatClient.Requests
{
    public class LoginRequest : Request
    {
        private int Id { get; }
        private string Password { get; }

        public LoginRequest(string key, int id, string password) : base(RequestCode.Login, key)
        {
            Id = id;
            Password = password;
        }
        
        public override string ToString()
        {
            string request = $"{Key.PadLeft(Constants.REQUEST_KEY_SEGMENT, '0')}{(int)Code}{Id.ToString().PadLeft(Constants.ID_SEGMNET, '0')}{Password}";
            return $"{request.Length.ToString().PadLeft(Constants.ID_SEGMNET, '0')}{request}";
        }
    }
}