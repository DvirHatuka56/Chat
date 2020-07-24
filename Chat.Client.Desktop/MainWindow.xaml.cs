using System.Windows;
using Chat.Client.Requests;

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

        private void Update_OnClick(object sender, RoutedEventArgs e)
        {
            Client.SendRequest(new UpdateRequest(ChatClient.GenerateKey(), new []{1111, 3339}));
        }
    }
}