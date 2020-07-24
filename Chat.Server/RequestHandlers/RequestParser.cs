namespace Chat.Server.RequestHandlers
{
    public class RequestParser
    {
        private string Raw { get;}
        private int Current { get; set; }

        public RequestParser(string raw)
        {
            Raw = raw;
            Current = 0;
        }

        public RequestParser(string raw, int start)
        {
            Raw = raw;
            Current = start;
        }

        public string Get(int length)
        {
            var substring = Raw.Substring(Current, length);
            Current += length;
            return substring;
        }

        public string Get()
        {
            return Raw.Substring(Current);
        }
        
        public int GetInt(int length)
        {
            var substring = Raw.Substring(Current, length);
            Current += length;
            return int.Parse(substring);
        }
    }
}