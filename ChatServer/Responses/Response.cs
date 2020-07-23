namespace ChatServer.Responses
{
    public enum ResponseCode
    {
        Success = 200,
        NewMessage = 300,
        Error = 400
    }
    
    public abstract class Response
    {
        public ResponseCode Code { get; }
        public string Key { get; }

        protected Response(ResponseCode code, string key)
        {
            Code = code;
            Key = key;
        }
        public new abstract string ToString();
    }
}