namespace ConsoleChatClient.Responses
{
    public enum ResponseCode
    {
        Success = 200,
        NewMessage = 300,
        Error = 400
    }
    
    public abstract class Response
    {
        public ResponseCode Code { get; set; }

        protected Response(string response)
        {
        }

        protected abstract void Deserialize(string response);
    }
}