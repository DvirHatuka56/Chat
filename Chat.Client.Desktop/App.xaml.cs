namespace Chat.Client.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public Chat.Client.ChatClient Client { get; set; }

        public App()
        {
            Client = new Chat.Client.ChatClient();
        }
    }
}