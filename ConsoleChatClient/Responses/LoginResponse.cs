using System;

namespace ConsoleChatClient.Responses
{
    public class LoginResponse : Response
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public LoginResponse(string key, string response) : base(ResponseCode.LoginSuccess, key, response)
        {
            Deserialize(response);
        }

        protected sealed override void Deserialize(string response)
        {
            if (!response.StartsWith(((int) Code).ToString()))
            {
                throw new FormatException($"The given response is not login response: {response}");
            }

            int i = Constants.CODE_SEGMNET;
            Id = int.Parse(response.Substring(i, Constants.ID_SEGMNET));

            i += Constants.ID_SEGMNET;
            Name = response.Substring(i);
        }
    }
}