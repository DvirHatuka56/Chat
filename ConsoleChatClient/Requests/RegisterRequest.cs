namespace ConsoleChatClient.Requests
{
    public class RegisterRequest : Request
    {
        private string Name { get; }
        private string Password { get; }

        public RegisterRequest(string name, string password)
        {
            Code = RequestCode.Register;
            Name = name;
            Password = password;
        }
        
        public override string ToString()
        {
            string request = $"{(int)Code}{Name.Length.ToString().PadLeft(Constants.NAME_LENGTH_SEGMENT, '0')}{Name}{Password}";
            return $"{request.Length.ToString().PadLeft(Constants.ID_SEGMNET, '0')}{request}";
        }
    }
}