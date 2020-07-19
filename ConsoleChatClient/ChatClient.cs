using ChatServer;
using ConsoleChatClient.Models;
using Network.Client;

namespace ConsoleChatClient
{
    public class ChatClient
    {
        public Client Client { get; }
        public User User { get; }

        public ChatClient(Client client, User user)
        {
            Client = client;
            User = user;
        }

        public ChatClient()
        {
            Client = new Client(Constants.IP, Constants.PORT);
            User = new User();
        }
        
        
    }
}