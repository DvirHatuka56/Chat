using System;
using System.Collections.Generic;
using System.Threading;
using Chat.Server.Models;
using Chat.Server.RequestHandlers;
using Chat.Server.Responses;

namespace Chat.Server
{
    public enum RequestCode
    {
        Hello = 999,
        Login = 100,
        Logout = 101,
        Register = 200,
        SendText = 300,
        SendFile = 301,
        Update = 500
    }
    
    public struct Request
    {
        public RequestCode RequestCode { get; set; }
        public string RequestKey { get; set; }
        public string RawRequest { get; set; }
    }
    
    public class Handler
    {
        private User User { get; }

        private readonly Dictionary<RequestCode, RequestHandler> RequestHandlers;

        public Handler(User user)
        {
            User = user;
            RequestHandlers = new Dictionary<RequestCode, RequestHandler>
            {
                {RequestCode.Login, new LoginHandler(user)},
                {RequestCode.Hello, new HelloHandler(user)},
                {RequestCode.Register, new RegisterHandler(user)},
                {RequestCode.Logout, new LogoutHandler(user)},
                {RequestCode.SendText, new SendTextHandler(user)},
                {RequestCode.Update, new UpdateHandler(user)}
            };
        }

        public Request GetRequest()
        {
            try
            {
                Monitor.Enter(User.Client);
                int len = User.Client.ReceiveInt(Constants.LENGTH_SEGMNET);
                string key = User.Client.ReceiveString(Constants.REQUEST_KEY_SEGMENT);
                string raw = User.Client.ReceiveString(len);
                Monitor.Exit(User.Client);
                
                Enum.TryParse(raw.Substring(0, Constants.CODE_SEGMNET),  out RequestCode code);
                return new Request
                {
                    RequestCode = code,
                    RequestKey = key,
                    RawRequest = raw
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new BadRequestException();
            }
        }

        public Response Handle(ChatServer server, Request request)
        {
            try
            {
                Monitor.Enter(User.Client);
                Response response = RequestHandlers[request.RequestCode].Handle(server, request);
                Monitor.Exit(User.Client);
                return response;
            }
            catch (KeyNotFoundException)
            {
                return new ErrorResponse(request.RequestKey, new BadRequestException());
            }
            catch (Exception e)
            {
                return new ErrorResponse(request.RequestKey, e);
            }
        }
    }
}