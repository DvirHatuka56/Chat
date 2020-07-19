using ChatServer.Models;

namespace ChatServer.Responses
{
    public class RegisterResponse : Response
    {
        private User User { get; }

        public RegisterResponse(User user)
        {
            User = user;
            Code = ResponseCode.Success;
        }

        public override string ToString(int lengthSegment)
        {
            string response = $"{(int)Code}{User.Id.ToString().PadLeft(Constants.ID_SEGMNET, '0')}{User.Name}";
            return $"{response.Length.ToString().PadLeft(lengthSegment, '0')}{response}";
        }
    }
}