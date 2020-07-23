using System;

namespace ChatServer.Responses
{
    public class ErrorResponse : Response
    {
        public Exception Exception { get; }
        
        public ErrorResponse(Exception exception) : base(ResponseCode.Error)
        {
            Exception = exception;
        }
        public override string ToString()
        {
            string response = $"{(int) Code}{Exception.Message}";
            return $"{response.Length.ToString().PadLeft(Constants.LENGTH_SEGMNET, '0')}{response}";
        }
    }
}