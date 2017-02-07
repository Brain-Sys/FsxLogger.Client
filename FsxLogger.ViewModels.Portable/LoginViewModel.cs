using FsxLogger.ViewModels.Messages;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Linq;

namespace FsxLogger.ViewModels.Portable
{
    public abstract class LoginViewModel : ApplicationViewModelBase
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
        }

        private void CancelLoginCommandExecute()
        {
            Messenger.Default.Send<CloseApplicationMessage>(CloseApplicationMessage.Empty);
        }

        protected abstract void LoginCommandExecute();
    }
}