using System.Windows;
using Chat.Client.Requests;

namespace Chat.Client.Desktop
{
    public partial class LoginWindow
    {
        private ChatClient Client { get; }
        public LoginWindow(ChatClient client)
        {
            InitializeComponent();
            Client = client;
        }

        private void Login_OnClick(object sender, RoutedEventArgs e)
        {
            Client.SendRequest(new LoginRequest(ChatClient.GenerateKey(), int.Parse(Id.Value), Password.Password));
        }

        private void Register_OnClick(object sender, RoutedEventArgs e)
        {
            Window prev = Application.Current.MainWindow;
            Application.Current.MainWindow = new RegisterWindow(((App) Application.Current).Client);
            prev?.Close();
            Application.Current.MainWindow.Show();
        }
    }
}