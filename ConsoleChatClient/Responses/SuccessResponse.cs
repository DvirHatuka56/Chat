using System;

namespace ConsoleChatClient.Responses
{
    public class SuccessResponse : Response
    {
        public SuccessResponse(string response) : base(ResponseCode.Success, response)
        {
            Deserialize(response);
        }

        protected sealed override void Deserialize(string response)
        {
            if (!response.StartsWith(((int) Code).ToString()))
            {
                throw new FormatException($"The given response is not success response: {response}");
            }
        }
    }
}