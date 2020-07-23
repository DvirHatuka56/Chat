using System;
using System.Collections.Generic;
using System.Threading;
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
            
            Thread thread= new Thread(TrySendNow);
            thread.Start(new Tuple<ChatServer, Message>(server, message));

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

        private void TrySendNow(object data)
        {
            if (!(data is Tuple<ChatServer, Message>)) return;
            ChatServer server = ((Tuple<ChatServer, Message>) data).Item1;
            Message message = ((Tuple<ChatServer, Message>) data).Item2;
            for (int i = 0; i < message.Recipients.Count; i++)
            {
                User user = server.GetUser(message.Recipients[i]);
                if (user == null) { continue; }

                UpdateHandler handler = new UpdateHandler(user);
                string one = "1".PadLeft(Constants.NAME_LENGTH_SEGMENT, '0');
                string chatId = message.ChatId.ToString().PadLeft(Constants.CHAT_SEGMNET, '0');
                Response response = handler.Handle(server, new Request
                {
                    RequestCode = RequestCode.Update,
                    RawRequest = $"{(int) RequestCode.Update}{one}{chatId}"
                });
                
                user.Client.SendMessage(response.ToString());
            }
        }
    }
}