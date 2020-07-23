namespace ChatServer.Responses
{
    public class SuccessResponse : Response
    {
        public SuccessResponse() : base(ResponseCode.Success) { }
        public override string ToString()
        {
            string response = $"{(int) Code}";
            return $"{response.Length.ToString().PadLeft(Constants.LENGTH_SEGMNET, '0')}{response}";
        }
    }
}