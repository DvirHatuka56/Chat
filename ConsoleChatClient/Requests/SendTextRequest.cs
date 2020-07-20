using System.Text;
using ConsoleChatClient.Models;

namespace ConsoleChatClient.Requests
{
    public class SendTextRequest : Request
    {
        private OutgoingMessage OutgoingMessage { get; }
        
        public SendTextRequest(OutgoingMessage outgoingMessage)
        {
            Code = RequestCode.SendText;
            OutgoingMessage = outgoingMessage;
        }
        
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append((int) Code);
            builder.Append(OutgoingMessage.ChatId.ToString().PadLeft(Constants.CHAT_SEGMNET, '0'));
            builder.Append(OutgoingMessage.Recipients.Count.ToString().PadLeft(Constants.RECIPIENTS_SEGMENT, '0'));
            foreach (int recipient in OutgoingMessage.Recipients)
            {
                builder.Append(recipient.ToString().PadLeft(Constants.ID_SEGMNET, '0'));
            }
            builder.Append(OutgoingMessage.Content);
            return $"{builder.Length.ToString().PadLeft(Constants.LENGTH_SEGMNET)}{builder}";
        }
    }
}