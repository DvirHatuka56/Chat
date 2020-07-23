namespace ChatServer.Responses
{
    public class SuccessResponse : Response
    {
        public SuccessResponse(string key) : base(ResponseCode.Success, key) { }
        public override string ToString()
        {
            string response = $"{Key.PadLeft(Constants.REQUEST_KEY_SEGMENT, '0')}{(int) Code}";
            return $"{response.Length.ToString().PadLeft(Constants.LENGTH_SEGMNET, '0')}{response}";
        }
    }
}