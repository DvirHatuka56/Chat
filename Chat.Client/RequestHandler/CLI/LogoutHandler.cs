using Chat.Client.Requests;

namespace Chat.Client.RequestHandler.CLI
{
    public class LogoutHandler : IRequestHandler
    {
        public void Handle(ChatClient client)
        {
            client.SendRequest(new LogoutRequest(ChatClient.GenerateKey()));
        }
    }
}