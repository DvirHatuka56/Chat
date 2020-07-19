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
        public ResponseCode Code { get; protected set; }
        public abstract string ToString(int lengthSegment);
    }
}