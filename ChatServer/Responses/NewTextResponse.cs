using System.Text;
using ChatServer.Models;

namespace ChatServer.Responses
{
    public class NewTextResponse : Response
    {
        private Message Message { get; }
        
        public NewTextResponse(Message message)
        {
            Message = message;
            Code = ResponseCode.NewMessage;
        }

        public override string ToString(int lengthSegment)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append((int) Code);
            builder.Append(Message.ChatId.ToString().PadLeft(Constants.CHAT_SEGMNET, '0'));
            builder.Append(Message.SenderId.ToString().PadLeft(Constants.ID_SEGMNET, '0'));
            builder.Append(Message.Time.ToString("ddMMyyyyhhmmss")); // 19072020125403 => 19.7.2020 12:54:03
            builder.Append(Message.Content);
            return $"{builder.Length.ToString().PadLeft(lengthSegment, '0')}{builder}";
        }
    }
}