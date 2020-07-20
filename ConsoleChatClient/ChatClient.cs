using System;
using ConsoleChatClient.Models;
using ConsoleChatClient.Requests;
using ConsoleChatClient.Responses;
using Network.Client;

namespace ConsoleChatClient
{
    public class ChatClient
    {
        private Client Client { get; }
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

            try
            {
                LoginResponse response = new LoginResponse(rawData);

                User.Id = response.Id;
                User.Name = response.Name;

                error = null;
                return true;
            }
            catch (FormatException)
            {
                error = new ErrorResponse(rawData);
                return false;
            }
        }

        public bool Hello(out ErrorResponse error)
        {
            Client.SendMessage(new HelloRequest().ToString());
            string rawData = ReceiveResponse();
            try
            {
                SuccessResponse response = new SuccessResponse(rawData);
                error = null;
                return true;
            }
            catch (FormatException)
            {
                error = new ErrorResponse(rawData);
                return false;
            }
        }

        public bool SendText(OutgoingMessage outgoingMessage, out ErrorResponse error)
        {
            string msg = new SendTextRequest(outgoingMessage).ToString();
            Client.SendMessage(msg);
            string raw = ReceiveResponse();
            try
            {
                SuccessResponse response = new SuccessResponse(raw);
                error = null;
                return true;
            }
            catch (FormatException)
            {
                error = new ErrorResponse(raw);
                return false;
            }
        }
        
        public bool Logout(out ErrorResponse error)
        {
            Client.SendMessage(new LogoutRequest().ToString());
            string rawData = ReceiveResponse();
            try
            {
                SuccessResponse response = new SuccessResponse(rawData);
                error = null;
                Client.Close();
                return true;
            }
            catch (FormatException)
            {
                error = new ErrorResponse(rawData);
                return false;
            }
        }

        private string ReceiveResponse()
        {
            int len = Client.ReceiveInt(Constants.ID_SEGMNET);
            return Client.ReceiveString(len);
        }
    }
}