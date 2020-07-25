namespace Chat.Client.Responses
{
    public enum ResponseCode
    {
        Success = 200,
        LoginSuccess = 210,
        RegisterSuccess = 220,
        NewMessage = 300,
        Error = 400
    }

    public struct ResponseData
    {
        public ResponseCode Code { get; set; }
        public string Key { get; set; }
        public string Raw { get; set; }
    }
    
    public abstract class Response
    {
        public ResponseCode Code { get; }
        public string Key { get; }
        public string Raw { get; }

        protected Response(ResponseCode code, string key, string response)
        {
            Code = code;
            Key = key;
            Raw = response;
        }

        protected abstract void Deserialize(string response);
    }
}