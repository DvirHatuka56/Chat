using System;
using Chat.Client.Requests;
using Chat.Client.Responses;

namespace Chat.Client.ResponseHandlers
{
    public class NewTextMessage : IResponseHandler
    {
        public void Handle(ChatClient client, ResponseData response)
        {
            NewTextResponse textResponse = new NewTextResponse(response.Key, response.Raw);
            //client.User.Chats[textResponse.IncomingMessage.ChatId].Messages.Add(textResponse.IncomingMessage);
            Console.WriteLine(textResponse.IncomingMessage);
            if (!textResponse.Key.Equals("".PadLeft(Constants.REQUEST_KEY_SEGMENT, '0')))
            {
                client.WaitingRequests.Remove(new RequestData
                {
                    Key = textResponse.Key
                });
            }
        }
    }
}