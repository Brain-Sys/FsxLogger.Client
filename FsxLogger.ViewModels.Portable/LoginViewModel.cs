using FsxLogger.ViewModels.Messages;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Linq;

namespace FsxLogger.ViewModels.Portable
{
    public class LoginViewModel : ApplicationViewModelBase
    {
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                base.RaisePropertyChanged();
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                base.RaisePropertyChanged();
            }
        }

        private bool loginOK;
        public bool LoginOK
        {
            get { return loginOK; }
            set
            {
                loginOK = value;
                base.RaisePropertyChanged();
            }
        }

        public RelayCommand LoginCommand { get; set; }
        public RelayCommand CancelLoginCommand { get; set; }

        public LoginViewModel()
        {
            this.LoginCommand = new RelayCommand(LoginCommandExecute);
            this.CancelLoginCommand = new RelayCommand(CancelLoginCommandExecute);

            this.Username = "igor";
            this.Password = "pwd";
        }

        private void CancelLoginCommandExecute()
        {
            Messenger.Default.Send<CloseApplicationMessage>(CloseApplicationMessage.Empty);
        }

        private void LoginCommandExecute()
        {
            this.LoginOK = (this.Username == "user" && this.Password == "pwd");

            var msg = new ShowDialogMessage();

            if (this.LoginOK == true)
            {
                msg.Title = "Login OK!";
                msg.Content = "Login successful!";
                msg.Icon = "Information";
            }
            else
            {
                msg.Title = "Login failed!";
                msg.Content = "Invalid credentials!";
            }

            Messenger.Default.Send<ShowDialogMessage>(msg);
        }
    }
}