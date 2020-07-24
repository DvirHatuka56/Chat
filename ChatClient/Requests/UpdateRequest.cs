using System.Collections.Generic;
using System.Text;

namespace ChatClient.Requests
{
    public class UpdateRequest : Request
    {
        private int[] Chats { get; }
        
        public UpdateRequest(string key, int[] chats) : base(RequestCode.Update, key)
        {
            Chats = chats;
        }
        
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Key.PadLeft(Constants.REQUEST_KEY_SEGMENT, '0'));
            builder.Append((int) Code);
            builder.Append(Chats.Length.ToString().PadLeft(Constants.TOTAL_IDS_SEGMENT, '0'));
            for (var i = 0; i < Chats.Length; i++)
            {
                builder.Append(Chats[i].ToString().PadLeft(Constants.CHAT_SEGMNET, '0'));
            }

            return $"{builder.Length.ToString().PadLeft(Constants.LENGTH_SEGMNET)}{builder}";
        }
    }
}