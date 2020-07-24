namespace Chat.Client
{
    internal class Program
    {
        public static void Main()
        {
            ChatClient client = new ChatClient();
            client.StartCLI();
            client.Close();
        }
    }
}