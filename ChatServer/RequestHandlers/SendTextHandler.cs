using System;
using System.Collections.Generic;
using ChatServer.Models;
using ChatServer.Responses;

namespace ChatServer.RequestHandlers
{
    public class SendTextHandler : RequestHandler
    {
        public SendTextHandler(User user) : base(user)
        {
        }

        public override Response Handle(ChatServer server, Request request)
        {
            int chatId = User.Client.ReceiveInt(Constants.CHAT_SEGMNET);
            var recipients = GetRecipients();
            string text = User.Client.ReceiveString(request.Length 
                                                    - Constants.CHAT_SEGMNET
                                                    - recipients.Count * Constants.ID_SEGMNET
                                                    - Constants.RECIPIENTS_SEGMENT);

            Message message = new Message(User.Id, DateTime.Now, chatId, recipients)
            {
                Content = text,
                ContentType = text.GetType()
            };

            if (!server.UnsentMessages.ContainsKey(chatId))
            {
                server.UnsentMessages.Add(chatId, new List<Message>
                {
                    message
                });
            }
            else
            {
                server.UnsentMessages[chatId].Add(message);
            }
            return new SuccessResponse();
        }

        private List<int> GetRecipients()
        {
            int count = User.Client.ReceiveInt(Constants.RECIPIENTS_SEGMENT);
            List<int> recipients = new List<int>(count);
            for (int i = 0; i < count; i++)
            {
                recipients.Add(User.Client.ReceiveInt(Constants.ID_SEGMNET));
            }

            return recipients;
        }

        private bool TrySendNow(ChatServer server, Message message)
        {
            throw new NotImplementedException();
        }
    }
}