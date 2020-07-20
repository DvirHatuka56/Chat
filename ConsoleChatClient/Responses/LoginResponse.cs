using System;

namespace ConsoleChatClient.Responses
{
    public class LoginResponse : Response
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public LoginResponse(string response) : base(response)
        {
            Code = ResponseCode.Success;
            Deserialize(response);
        }

        protected sealed override void Deserialize(string response)
        {
            if (!response.Substring(0, Constants.CODE_SEGMNET).Equals("200")) { throw new FormatException(); }

            int i = Constants.CODE_SEGMNET;
            Id = int.Parse(response.Substring(i, Constants.ID_SEGMNET));

            i += Constants.ID_SEGMNET;
            Name = response.Substring(i);
        }
    }
}