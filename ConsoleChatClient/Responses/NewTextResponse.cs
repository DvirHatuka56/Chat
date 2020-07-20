using System;
using System.Globalization;
using ConsoleChatClient.Models;

namespace ConsoleChatClient.Responses
{
    public class NewTextResponse : Response
    {
        public Message Message { get; set; }
        
        public NewTextResponse(string response) : base(response)
        {
            Code = ResponseCode.NewMessage;
            Deserialize(response);
        }

        protected sealed override void Deserialize(string response)
        {
            int i = 0;
            
            int chatId = int.Parse(response.Substring(i, Constants.CHAT_SEGMNET));
            i = Constants.CHAT_SEGMNET;
            
            int senderId = int.Parse(response.Substring(i, Constants.ID_SEGMNET));
            i += Constants.CHAT_SEGMNET + Constants.ID_SEGMNET;
            
            DateTime time = DateTime.ParseExact(response.Substring(i, Constants.TIME_SEGMENT), "ddMMyyyyhhmmss", new NumberFormatInfo());
            i += Constants.TIME_SEGMENT;

            string content = response.Substring(i);
            
            Message = new Message(senderId, time, chatId)
            {
                Content = content
            };
        }
    }
}