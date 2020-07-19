using ChatServer;
using ConsoleChatClient.Models;
using ConsoleChatClient.Requests;
using ConsoleChatClient.Responses;
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

        public bool Login(int id, string password, out ErrorResponse error)
        {
            Client.SendMessage(new LoginRequest(id, password).ToString());
            string rawData = ReceiveResponse();
            if (rawData != "200")
            {
                error = new ErrorResponse();
                error.Deserialize(rawData);
                return false;
            }
            
            LoginResponse response = new LoginResponse();
            response.Deserialize(rawData);

            User.Id = response.Id;
            User.Name = response.Name;

            error = null;
            return true;
        }

        private string ReceiveResponse()
        {
            int len = Client.ReceiveInt(Constants.ID_SEGMNET);
            return Client.ReceiveString(len);
        }
    }
}