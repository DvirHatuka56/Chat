using ConsoleChatClient.Requests;

namespace ConsoleChatClient.RequestHandler.CLI
{
    public class UpdateHandler : IRequestHandler
    {
        public void Handle(ChatClient client)
        {
            UpdateRequest request = new UpdateRequest(ChatClient.GenerateKey(), new []{1111, 3339});
            client.SendRequest(request);
        }
    }
}