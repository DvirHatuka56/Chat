﻿using System;
using System.Collections.Generic;

namespace Chat.Client.RequestHandler.CLI
{
    // ReSharper disable once InconsistentNaming
    public class CLIRequestManager : RequestManager
    {
        public CLIRequestManager(ChatClient client) : base(client)
        {
            Handlers = new Dictionary<string, IRequestHandler>
            {
                { "login", new LoginHandler() },
                { "send", new SendTextHandler() },
                { "logout", new LogoutHandler() },
                { "hello", new HelloHandler() },
                { "update", new UpdateHandler()}
            };
        }
        
        public override void Manage()
        {
            string command = "";
            while (!(command.Equals("stop") || command.Equals("logout")))
            {
                command = Console.ReadLine() ?? "";
                if (command.Equals("stop"))
                {
                    return;
                }
                if (Handlers.ContainsKey(command))
                {
                    Handlers[command].Handle(Client);
                }
            }
        }
    }
}