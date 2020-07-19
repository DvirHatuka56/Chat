namespace ConsoleChatClient.Requests
{
    public enum RequestCode
    {
        Hello = 999,
        Login = 100,
        Logout = 101,
        Register = 200,
        SendText = 300,
        SendFile = 301,
        Update = 500
    }
    
    public abstract class Request
    {
        public RequestCode Code { get; set; }
        public new abstract string ToString();
    }
}