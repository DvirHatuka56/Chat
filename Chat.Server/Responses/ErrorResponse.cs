using System;

namespace Chat.Server.Responses
{
    public class ErrorResponse : Response
    {
        public Exception Exception { get; }
        
        public ErrorResponse(string key, Exception exception) : base(ResponseCode.Error, key)
        {
            Exception = exception;
        }
        public override string ToString()
        {
            string response = $"{Key.PadLeft(Constants.REQUEST_KEY_SEGMENT, '0')}{(int) Code}{Exception.Message}";
            return $"{response.Length.ToString().PadLeft(Constants.LENGTH_SEGMNET, '0')}{response}";
        }
    }
}