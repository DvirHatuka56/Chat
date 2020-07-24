﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using ChatClient.Models;
using ChatClient.RequestHandler;
using ChatClient.RequestHandler.CLI;
using ChatClient.Requests;
using ChatClient.ResponseHandlers;
using ChatClient.Responses;
using Network.Client;
using LoginHandler = ChatClient.ResponseHandlers.LoginHandler;

namespace ChatClient
{
    public class ChatClient
    {
        public User User { get; }
        public List<RequestData> WaitingRequests { get; }
        private Client Client { get; set; }
        private Queue<ResponseData> Responses { get; }
        private Dictionary<ResponseCode, IResponseHandler> Handlers { get; }
        private Thread ReaderThread { get; }
        private event EventHandler NewResponse;
        
        public ChatClient()
        {
            Client = new Client(Constants.IP, Constants.PORT);
            User = new User();
            Responses = new Queue<ResponseData>();
            WaitingRequests = new List<RequestData>();
            Handlers = new Dictionary<ResponseCode, IResponseHandler>
            {
                {ResponseCode.Success, new SuccessHandler()},
                {ResponseCode.LoginSuccess, new ResponseHandlers.LoginHandler()},
                {ResponseCode.Error, new ErrorHandler()},
                {ResponseCode.NewMessage, new NewTextMessage()}
            };
            ReaderThread = new Thread(Reader);
            NewResponse += OnNewResponse;
        }

        public void Restart()
        {
            Client = new Client(Constants.IP, Constants.PORT);
        }

        public void Start(RequestManager manager)
        {
            ReaderThread.Start();
            manager.Manage();
        }

        public void StartCLI()
        {
            Start(new CLIRequestManager(this));
        }

        private void OnNewResponse(object sender, EventArgs e)
        {
            while (Responses.Count != 0)
            {
                var response = Responses.Dequeue();
                Handlers[response.Code].Handle(this, response);
            }
        }

        private void Reader()
        {
            while (true)
            {
                try
                {
                    Responses.Enqueue(ReadResponse());
                    NewResponse?.Invoke(null, EventArgs.Empty);
                }
                catch (ThreadAbortException)
                {
                    return;
                }
                catch (Exception)
                {
                    
                }
            }
        }

        private ResponseData ReadResponse()
        {
            int len = Client.ReceiveInt(Constants.LENGTH_SEGMNET);
            string raw = Client.ReceiveString(len);
            string key = raw.Substring(0, Constants.REQUEST_KEY_SEGMENT);
            raw = raw.Substring(Constants.REQUEST_KEY_SEGMENT);
            Enum.TryParse(raw.Substring(0, Constants.CODE_SEGMNET), out ResponseCode code);
            return new ResponseData
            {
                Code = code,
                Key = key,
                Raw = raw
            };
        }

        public void SendRequest(Request request)
        {
            Client.SendMessage(request.ToString());
            WaitingRequests.Add(new RequestData
            {
                Code = request.Code,
                Key = request.Key
            });
        }

        public static string GenerateKey()
        {
            int size = Constants.REQUEST_KEY_SEGMENT;
            char[] chars =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray(); 
            byte[] data = new byte[4*size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();
        }

        public void Close()
        {
            if (ReaderThread.IsAlive)
            {
                ReaderThread.Abort();
            }
            if (Client.IsConnected)
            {
                Client.Close();
            }
        }
    }
}