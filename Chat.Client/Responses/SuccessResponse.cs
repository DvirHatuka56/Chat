using System;

namespace Chat.Client.Responses
{
    public class SuccessResponse : Response
    {
        public SuccessResponse(string key, string response) : base(ResponseCode.Success, key, response)
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