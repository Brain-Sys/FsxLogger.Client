using FsxLogger.ViewModels.Portable;
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
            PasswordBox pb = (PasswordBox)sender;
            this.ViewModel.Password = pb.Password;
        }
    }
}