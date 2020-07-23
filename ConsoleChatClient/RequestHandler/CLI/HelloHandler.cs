using ConsoleChatClient.Requests;

namespace ConsoleChatClient.RequestHandler.CLI
{
    public class HelloHandler : IRequestHandler
    {
        public void Handle(ChatClient client)
        {
            client.SendRequest(new HelloRequest(ChatClient.GenerateKey()));
        }
    }
}