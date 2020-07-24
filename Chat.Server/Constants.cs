using System;

namespace Chat.Server
{
    public class Constants
    {
        public const int ID_SEGMNET = 4;
        public const int CHAT_SEGMNET = 4;
        public const int LENGTH_SEGMNET = 4;
        public const int CODE_SEGMNET = 3;
        public const int NAME_LENGTH_SEGMENT = 2;
        public const int TOTAL_IDS_SEGMENT = 2;
        public const int RECIPIENTS_SEGMENT = 3;
        public const int REQUEST_KEY_SEGMENT = 8;

        public static string GetConnectionString()
        {
            return $@"Data Source={Environment.CurrentDirectory}\Database\Chat.db;Version=3;UseUTF16Encoding=True;";
        }
    }
}