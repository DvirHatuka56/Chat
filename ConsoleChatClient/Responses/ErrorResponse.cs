namespace ConsoleChatClient.Responses
{
    public class ErrorResponse : Response
    {
        public string Error { get; set; }

        public ErrorResponse()
        {
            Code = ResponseCode.Error;
        }

        public void Deserialize(string response)
        {
            Error = response;
        }
    }
}