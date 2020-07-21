using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public List<IncomingMessage> Update(List<int> chats, out ErrorResponse error)
        {
            Client.SendMessage(new UpdateRequest(chats).ToString());
            List<IncomingMessage> messages = new List<IncomingMessage>();
            NewTextResponse response;
            string raw = ReceiveResponse();
            do
            {
                try
                {   
                    if (IsSuccess(raw)) { break; }
                    response = new NewTextResponse(raw);
                    messages.Add(response.IncomingMessage);
                    raw = ReceiveResponse();
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e);
                    error = new ErrorResponse(raw);
                    return null;
                }
            } while (response.Code != ResponseCode.Success);

            error = null;
            return messages;
        }
        
        public IncomingMessage[] LiveUpdate(out ErrorResponse error)
        {
            List<IncomingMessage> messages = new List<IncomingMessage>();
            NewTextResponse response;
            string raw = ReceiveResponse();
            do
            {
                try
                {   
                    if (IsSuccess(raw)) { break; }
                    response = new NewTextResponse(raw);
                    messages.Add(response.IncomingMessage);
                    raw = ReceiveResponse();
                }
                catch (FormatException)
                {
                    error = new ErrorResponse(raw);
                    return null;
                }
            } while (response.Code != ResponseCode.Success);

            error = null;
            return messages.ToArray();
        }

        private bool IsSuccess(string raw)
        {
            try
            {
                SuccessResponse response = new SuccessResponse(raw);
                return true;
            }
            catch (FormatException)
            {
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
            int len = Client.ReceiveInt(Constants.LENGTH_SEGMNET);
            return Client.ReceiveString(len);
        }
    }
}