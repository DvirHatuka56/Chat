using System.Collections.Generic;
using ChatServer.Models;
using ChatServer.Responses;

namespace ChatServer.RequestHandlers
{
    public class UpdateHandler : RequestHandler
    {
        public UpdateHandler(User user) : base(user)
        {
        }

        public override Response Handle(ChatServer server, Request request)
        {
            int[] ids = ReadChatIds();
            
            foreach (var id in ids)
            {
                if (!server.UnsentMessages.ContainsKey(id) || server.UnsentMessages[id] == null) continue;
                int count = server.UnsentMessages[id].Count;
                for (var i = 0; i < count; i++)
                {
                    var message = server.UnsentMessages[id][i];
                    if (message.Recipients.Contains(User.Id))
                    {
                        User.Client.SendMessage(new NewTextResponse(message).ToString(Constants.LENGTH_SEGMNET));
                    }

                    message.Recipients.Remove(User.Id);
                    if (message.Recipients.Count == 0)
                    {
                        server.UnsentMessages[id].Remove(message);
                        --i;
                        --count;
                    }

                    if (server.UnsentMessages[id].Count == 0)
                    {
                        server.UnsentMessages.Remove(id);
                    }
                }
            }
            
            return new SuccessResponse();
        }

        private int[] ReadChatIds()
        {
            int len = User.Client.ReceiveInt(Constants.TOTAL_IDS_SEGMENT);
            int[] ids = new int[len];
            for (int i = 0; i < len; i++)
            {
                ids[i] = User.Client.ReceiveInt(Constants.CHAT_SEGMNET);
            }

            return ids;
        }
    }
}