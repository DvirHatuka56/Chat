using System.Windows;
using Chat.Client.Requests;

namespace Chat.Client.Desktop
{
    public partial class RegisterWindow
    {
        private ChatClient Client { get; }
        
        public RegisterWindow(ChatClient client)
        {
            InitializeComponent();
            Client = client;
        }

        private void Register_OnClick(object sender, RoutedEventArgs e)
        {
            if (!Password.Password.Equals(RePassword.Password))
            {
                MessageBox.Show("Passwords do not match");
                return;
            }
            Client.SendRequest(new RegisterRequest(ChatClient.GenerateKey(), Username.Value, Password.Password));
        }

        private void Login_OnClick(object sender, RoutedEventArgs e)
        {
            Window prev = Application.Current.MainWindow;
            Application.Current.MainWindow = new LoginWindow(((App) Application.Current).Client);
            prev?.Close();
            Application.Current.MainWindow.Show();
        }
    }
}