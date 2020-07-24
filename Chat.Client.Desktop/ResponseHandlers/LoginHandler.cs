using System.Windows;
using Chat.Client.ResponseHandlers;
using Chat.Client.Responses;

namespace Chat.Client.Desktop.ResponseHandlers
{
    public class LoginHandler : IResponseHandler
    {
        public void Handle(ChatClient client, ResponseData response)
        {
            LoginResponse loginResponse = new LoginResponse(response.Key, response.Raw);
            client.User.Id = loginResponse.Id;
            client.User.Name = loginResponse.Name;

            Application.Current.Dispatcher.Invoke(() =>
            {
                Window prev = Application.Current.MainWindow;
                Application.Current.MainWindow = new MainWindow(((App) Application.Current).Client);
                prev?.Close();
                Application.Current.MainWindow.Show();
            });

        }
    }
}