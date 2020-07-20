using System.Collections.Generic;
using System.Text;

namespace ConsoleChatClient.Requests
{
    public class UpdateRequest : Request
    {
        private List<int> Chats { get; }
        
        public UpdateRequest(List<int> chats) : base(RequestCode.Update)
        {
            Chats = chats;
        }
        
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append((int) Code);
            builder.Append(Chats.Count.ToString().PadLeft(Constants.TOTAL_IDS_SEGMENT, '0'));
            foreach (var chat in Chats)
            {
                builder.Append(chat.ToString().PadLeft(Constants.CHAT_SEGMNET, '0'));
            }

            return $"{builder.Length.ToString().PadLeft(Constants.LENGTH_SEGMNET)}{builder}";
        }
    }
}