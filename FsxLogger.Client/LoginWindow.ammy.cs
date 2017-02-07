using FsxLogger.ViewModels.Wpf;
using System.Windows;
using System.Windows.Controls;

namespace FsxLogger.Client
{
    public partial class LoginWindow
    {
        public LoginViewModel ViewModel { get; private set; }

        public LoginWindow()
        {
            InitializeComponent();
            this.ViewModel = this.Resources["vm"] as LoginViewModel;
        }

        private void changed(object sender, RoutedEventArgs e)
        {
            this.ViewModel.Password.Clear();

            PasswordBox pb = (PasswordBox)sender;

            foreach (char c in pb.Password)
            {
                this.ViewModel.Password.AppendChar(c);
            }
        }
    }
}