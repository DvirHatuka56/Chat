namespace ConsoleChatClient.Requests
{
    public class LogoutRequest : Request
    {
        public LogoutRequest() : base(RequestCode.Logout) { }
        
        public override string ToString()
        {
            string request = $"{(int)Code}";
            return $"{request.Length.ToString().PadLeft(Constants.ID_SEGMNET, '0')}{request}";
        }
    }
}