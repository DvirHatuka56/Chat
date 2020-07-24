namespace Chat.Client.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private ChatClient Client { get; }
        public MainWindow(ChatClient client)
        {
            InitializeComponent();
            Client = client;
            Label.Content = $"{Client.User} logged in";
        }
    }
}