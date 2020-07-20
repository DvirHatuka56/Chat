using System;

namespace ConsoleChatClient.Requests
{
    public class HelloRequest : Request
    {
        public HelloRequest()
        {
            Code = RequestCode.Hello;
        }
        public override string ToString()
        {
            string request = $"{(int)Code}";
            return $"{request.Length.ToString().PadLeft(Constants.ID_SEGMNET, '0')}{request}";
        }
    }
}