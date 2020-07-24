using System.Collections.Generic;
using System.Threading;
using Chat.Server.Models;
using Chat.Server.Responses;

namespace Chat.Server.RequestHandlers
{
    public class UpdateHandler : RequestHandler
    {
        public UpdateHandler(User user) : base(user)
        {
        }

        public override Response Handle(ChatServer server, Request request)
        {
            RequestParser parser = new RequestParser(request.RawRequest, Constants.CODE_SEGMNET);
            int[] ids = ReadChatIds(parser);
            
            Monitor.Enter(server.UnsentMessages);
            foreach (var id in ids)
            {
                if (!server.UnsentMessages.ContainsKey(id) || server.UnsentMessages[id] == null) continue;
                int count = server.UnsentMessages[id].Count;
                for (var i = 0; i < count; i++)
                {
                    var message = server.UnsentMessages[id][i];
                    if (message.Recipients.Contains(User.Id))
                    {
                        User.Client.SendMessage(new NewTextResponse(request.RequestKey, message).ToString());
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
            Monitor.Exit(server.UnsentMessages);
            return new SuccessResponse(request.RequestKey);
        }

        private int[] ReadChatIds(RequestParser parser)
        {
            int len = parser.GetInt(Constants.TOTAL_IDS_SEGMENT);
            int[] ids = new int[len];
            for (int i = 0; i < len; i++)
            {
                ids[i] = parser.GetInt(Constants.CHAT_SEGMNET);
            }

            return ids;
        }
    }
}