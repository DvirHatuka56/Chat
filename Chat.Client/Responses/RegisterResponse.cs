using System;
using Chat.Client.Models;

namespace Chat.Client.Responses
{
    public class RegisterResponse : Response
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        
        public RegisterResponse(ResponseCode code, string key, string response) : base(code, key, response)
        {
        }

        protected override void Deserialize(string response)
        {
            if (!response.StartsWith(((int) Code).ToString()))
            {
                throw new FormatException($"The given response is not login response: {response}");
            }
            
            Id = int.Parse(response.Substring(Constants.CODE_SEGMNET, Constants.ID_SEGMNET));
            Name = response.Substring(Constants.CODE_SEGMNET + Constants.ID_SEGMNET);
        }
    }
}