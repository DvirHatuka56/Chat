using System.Collections.Generic;
using System.Windows.Controls;

namespace Chat.Client.Desktop.Controls
{
    public partial class ChatList
    {
        private List<Models.Chat> _chats;

        public List<Models.Chat> Chats
        {
            get => _chats;
            set
            {
                _chats = value;
                ChatsList.ItemsSource = value;
            }
        }

        public ChatList()
        {
            InitializeComponent();
            ChatsList.ItemsSource = Chats;
        }

        private void SearchBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                ChatsList.ItemsSource = Chats;
            }
            List<Models.Chat> chats = new List<Models.Chat>();
            foreach (var chat in Chats)
            {
                if (chat.Name.Equals(SearchBox.Text))
                {
                    chats.Add(chat);
                }
            }

            ChatsList.ItemsSource = chats;
        }
    }
}