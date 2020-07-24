using System.Windows;
using System.Windows.Controls;

namespace Chat.Client.Desktop.Controls
{
    public partial class Field
    {
        public string Display
        {
            get => FieldName.Content.ToString();
            set => FieldName.Content = value;
        }

        public string Value => FieldValue.Text;
        public string Password => FieldPasswordValue.Password;

        public bool IsPassword
        {
            get => FieldValue.Visibility == Visibility.Collapsed;
            set
            {
                if (value)
                {
                    FieldValue.Visibility = Visibility.Collapsed;
                    FieldPasswordValue.Visibility = Visibility.Visible;
                }
                else
                {
                    FieldValue.Visibility = Visibility.Visible;
                    FieldPasswordValue.Visibility = Visibility.Collapsed;
                }
            }
        }

        public Field()
        {
            InitializeComponent();
        }
    }
}