namespace Chat.Client.Requests
{
    public class LogoutRequest : Request
    {
        public LogoutRequest(string key) : base(RequestCode.Logout, key) { }
        
        public override string ToString()
        {
            string request = $"{Key.PadLeft(Constants.REQUEST_KEY_SEGMENT, '0')}{(int)Code}";
            return $"{request.Length.ToString().PadLeft(Constants.ID_SEGMNET, '0')}{request}";
        }
    }
}