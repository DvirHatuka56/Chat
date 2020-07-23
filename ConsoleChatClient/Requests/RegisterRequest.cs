namespace ConsoleChatClient.Requests
{
    public class RegisterRequest : Request
    {
        private string Name { get; }
        private string Password { get; }

        public RegisterRequest(string key, string name, string password) : base(RequestCode.Register, key)
        {
            Name = name;
            Password = password;
        }
        
        public override string ToString()
        {
            string request = $"{Key.PadLeft(Constants.REQUEST_KEY_SEGMENT, '0')}{(int)Code}{Name.Length.ToString().PadLeft(Constants.NAME_LENGTH_SEGMENT, '0')}{Name}{Password}";
            return $"{request.Length.ToString().PadLeft(Constants.ID_SEGMNET, '0')}{request}";
        }
    }
}