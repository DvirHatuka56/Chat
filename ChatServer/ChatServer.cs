using System;
using System.Collections.Generic;
using System.Text;
using ChatServer.Models;
using ChatServer.Responses;
using Network.Client;
using Network.Server;

namespace ChatServer
{
    public class ChatServer
    {
        private ThreadPoolServer Server { get; }
        private HashSet<User> Users { get; }
        public Dictionary<int, List<Message>> UnsentMessages { get; }
        
        
        public ChatServer()
        {
            Server = new ThreadPoolServer();
            Server.HandleClient += ServerOnHandleClient;
            Users = new HashSet<User>();
            UnsentMessages = new Dictionary<int, List<Message>>();
            
        }

        public ChatServer(ThreadPoolServer server, HashSet<User> users)
        {
            Server = server;
            Server.HandleClient += ServerOnHandleClient;
            Users = new HashSet<User>();
            Users = users;
            UnsentMessages = new Dictionary<int, List<Message>>();
        }

        public void Start()
        {
            Server.Start();
        }

        private void ServerOnHandleClient(object sender, Client e)
        {
            Request request;
            User user = new User(e);
            do
            {
                try
                {
                    var handler = new Handler(user);
                    request = handler.GetRequest();
                    
                    if (request.RequestCode != RequestCode.Login && request.RequestCode != RequestCode.Register && !Users.Contains(user))
                    {
                        e.SendMessage(new ErrorResponse(new BadRequestException()).ToString());
                        e.Close();
                        break;
                    }
                    
                    Console.WriteLine(request.RequestCode);
                    
                    Response response = handler.Handle(this, request);
                    user.Client.SendMessage(response.ToString());
                    
                    Console.WriteLine(UsersToString());
                    
                    if (response.Code != ResponseCode.Error) continue;
                    Console.WriteLine((response as ErrorResponse)?.Exception.Message);
                    e.Close();
                    RemoveUser(user);
                    break;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    e.SendMessage(new ErrorResponse(exception).ToString());
                    e.Close();
                    RemoveUser(user);
                    break;
                }
            } while (request.RequestCode != RequestCode.Logout);
        }

        public User GetUser(int id)
        {
            foreach (var user in Users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }

            return null;
        }

        private string UsersToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var user in Users)
            {
                builder.Append($"{user}{Environment.NewLine}");
            }

            return builder.ToString();
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public void RemoveUser(User user)
        {
            Users.Remove(user);
        }

        public void Close()
        {
            foreach (var user in Users)
            {
                user.Client.Close();
            }

            Server.Close();
        }
    }
}