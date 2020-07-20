namespace ConsoleChatClient
{
    internal class Program
    {
        public static void Main()
        {
            ChatClient client = new ChatClient();
            client.Login(2, "1234", out _);
            client.Logout(out _);
        }
    }
}