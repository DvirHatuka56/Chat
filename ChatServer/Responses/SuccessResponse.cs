namespace ChatServer.Responses
{
    public class SuccessResponse : Response
    {
        public SuccessResponse()
        {
            Code = ResponseCode.Success;
        }
        public override string ToString(int lengthSegment)
        {
            string response = $"{(int)ResponseCode.Success}";
            return $"{response.Length.ToString().PadLeft(lengthSegment, '0')}{response}";
        }
    }
}