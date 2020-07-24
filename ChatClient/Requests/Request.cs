namespace ChatClient.Requests
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

    public struct RequestData
    {
        public RequestCode Code { get; set; }
        public string Key { get; set; }

        public override bool Equals(object obj)
        {
            return Key == (obj is RequestData data ? data : default).Key;
        }

        public bool Equals(RequestData other)
        {
            return Key == other.Key;
        }

        public override int GetHashCode()
        {
            return (Key != null ? Key.GetHashCode() : 0);
        }
    }
    
    public abstract class Request
    {
        public RequestCode Code { get; }
        public string Key { get; }

        protected Request(RequestCode code, string key)
        {
            Code = code;
            Key = key;
        }
        public new abstract string ToString();
    }
}