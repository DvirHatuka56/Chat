using System;
using ConsoleChatClient.Requests;

namespace ConsoleChatClient.Responses
{
    public class ErrorResponse : Response
    {
        public string Error { get; set; }

        public ErrorResponse(string response) : base(ResponseCode.Error, response)
        {
            Deserialize(response);
        }

        protected sealed override void Deserialize(string response)
        {
            if (!response.StartsWith(((int) Code).ToString()))
            {
                throw new FormatException($"The given response is not error response: {response}");
            }

            Error = response.Substring(Constants.CODE_SEGMNET);
        }
    }
}