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
            Client.SendRequest(new RegisterRequest(ChatClient.GenerateKey(), Name.Value, Password.Password));
        }
    }
}