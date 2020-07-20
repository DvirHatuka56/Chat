using System;

namespace ConsoleChatClient.Responses
{
    public class SuccessResponse : Response
    {
        public SuccessResponse(string response) : base(response)
        {
            Code = ResponseCode.Success;
            Deserialize(response);
        }

        protected sealed override void Deserialize(string response)
        {
            if (!response.StartsWith(((int) ResponseCode.Success).ToString()))
            {
                throw new FormatException("The given response is not success response");
            }
        }
    }
}