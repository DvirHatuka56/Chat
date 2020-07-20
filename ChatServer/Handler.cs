using System;
using System.Collections.Generic;
using ChatServer.Models;
using ChatServer.RequestHandlers;
using ChatServer.Responses;

namespace ChatServer
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
                int len = User.Client.ReceiveInt(Constants.LENGTH_SEGMNET);
                string raw = User.Client.ReceiveString(len);
                Enum.TryParse(raw.Substring(0, Constants.CODE_SEGMNET),  out RequestCode code);
                return new Request
                {
                    RequestCode = code,
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
                return RequestHandlers[request.RequestCode].Handle(server, request);
            }
            catch (KeyNotFoundException)
            {
                return new ErrorResponse(new BadRequestException());
            }
            catch (Exception e)
            {
                return new ErrorResponse(e);
            }
        }
    }
}