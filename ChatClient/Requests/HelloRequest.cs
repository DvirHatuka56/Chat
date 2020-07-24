using System;

namespace ChatClient.Requests
{
    public class HelloRequest : Request
    {
        public HelloRequest(string key) : base(RequestCode.Hello, key) { }
        public override string ToString()
        {
            string request = $"{Key.PadLeft(Constants.REQUEST_KEY_SEGMENT, '0')}{(int)Code}";
            return $"{request.Length.ToString().PadLeft(Constants.ID_SEGMNET, '0')}{request}";
        }
    }
}