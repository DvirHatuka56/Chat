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

        protected Response(ResponseCode code)
        {
            Code = code;
        }
        public new abstract string ToString();
    }
}