using Chat.Client.Requests;

namespace Chat.Client.RequestHandler.CLI
{
    public class HelloHandler : IRequestHandler
    {
        public void Handle(ChatClient client)
        {
            client.SendRequest(new HelloRequest(ChatClient.GenerateKey()));
        }
    }
}