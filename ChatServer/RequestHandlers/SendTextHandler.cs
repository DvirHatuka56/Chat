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
            RequestParser parser = new RequestParser(request.RawRequest, Constants.CODE_SEGMNET);
            int chatId = parser.GetInt(Constants.CHAT_SEGMNET);
            var recipients = GetRecipients(parser);
            string text = parser.Get();

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

        private List<int> GetRecipients(RequestParser parser)
        {
            int count = parser.GetInt(Constants.RECIPIENTS_SEGMENT);
            List<int> recipients = new List<int>(count);
            for (int i = 0; i < count; i++)
            {
                recipients.Add(parser.GetInt(Constants.ID_SEGMNET));
            }

            return recipients;
        }

        private bool TrySendNow(ChatServer server, Message message)
        {
            throw new NotImplementedException();
        }
    }
}