using System.Windows;
using Chat.Client.ResponseHandlers;
using Chat.Client.Responses;

namespace Chat.Client.Desktop.ResponseHandlers
{
    public class NewTextHandler : IResponseHandler
    {
        public void Handle(ChatClient client, ResponseData response)
        {
            NewTextResponse textResponse = new NewTextResponse(response.Key, response.Raw);
            //client.User.Chats[textResponse.IncomingMessage.ChatId].Messages.Add(textResponse.IncomingMessage);

            MessageBox.Show(textResponse.IncomingMessage.ToString());
        }
    }
}