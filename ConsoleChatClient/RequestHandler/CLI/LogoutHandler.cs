using ConsoleChatClient.Requests;

namespace ConsoleChatClient.RequestHandler.CLI
{
    public class LogoutHandler : IRequestHandler
    {
        public void Handle(ChatClient client)
        {
            client.SendRequest(new LogoutRequest(ChatClient.GenerateKey()));
        }
    }
}