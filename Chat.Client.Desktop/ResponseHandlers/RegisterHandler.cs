using System.Windows;
using Chat.Client.ResponseHandlers;
using Chat.Client.Responses;

namespace Chat.Client.Desktop.ResponseHandlers
{
    public class RegisterHandler : IResponseHandler
    {
        public void Handle(ChatClient client, ResponseData response)
        {
            RegisterResponse registerResponse = new RegisterResponse(response.Key, response.Raw);
            client.User.Id = registerResponse.Id;
            client.User.Name = registerResponse.Name;
            
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