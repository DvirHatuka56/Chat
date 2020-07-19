using System;

namespace ChatServer.Responses
{
    public class ErrorResponse : Response
    {
        public Exception Exception { get; }
        
        public ErrorResponse(Exception exception)
        {
            Code = ResponseCode.Error;
            Exception = exception;
        }
        public override string ToString(int lengthSegment)
        {
            string response = $"{(int)ResponseCode.Error}{Exception.Message}";
            return $"{response.Length.ToString().PadLeft(lengthSegment, '0')}{response}";
        }
    }
}