using System.Collections.Generic;
using System.Windows;
using Chat.Client.Requests;
using Chat.Client.ResponseHandlers;
using Chat.Client.Responses;
using LoginHandler = Chat.Client.Desktop.ResponseHandlers.LoginHandler;
using ErrorHandler = Chat.Client.Desktop.ResponseHandlers.ErrorHandler;
using NewTextHandler = Chat.Client.Desktop.ResponseHandlers.NewTextHandler;

namespace Chat.Client.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public ChatClient Client { get; }
        
        public App()
        {
            Client = new ChatClient(new Dictionary<ResponseCode, IResponseHandler>
            {
                {ResponseCode.LoginSuccess, new LoginHandler()},
                {ResponseCode.Success, new SuccessHandler()},
                {ResponseCode.Error, new ErrorHandler()},
                {ResponseCode.NewMessage, new NewTextHandler()}
            });
            MainWindow = new LoginWindow(Client);
            MainWindow.Show();
        }

        private void App_OnExit(object sender, ExitEventArgs e)
        {
            Client.SendRequest(new LogoutRequest(ChatClient.GenerateKey()));
            Client.Close();
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            Client.Start();
        }
    }
}