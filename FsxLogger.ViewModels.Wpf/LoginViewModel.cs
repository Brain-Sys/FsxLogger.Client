using FsxLogger.Translations;
using FsxLogger.ViewModels.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using WPFLocalizeExtension.Engine;

namespace FsxLogger.ViewModels.Wpf
{
    public class LoginViewModel : FsxLogger.ViewModels.Portable.LoginViewModel
    {
        private SecureString password;
        public SecureString Password
        {
            get { return password; }
            set { password = value;
                base.RaisePropertyChanged();
            }
        }

        public RelayCommand ChangeLanguageCommand { get; set; }

        public LoginViewModel()
        {
            this.ChangeLanguageCommand = new RelayCommand(changeLanguageCommandExecute);

            this.Password = new SecureString();
        }

        private void changeLanguageCommandExecute()
        {
            new TranslationsManager().ChangeLanguage();
        }

        protected override void LoginCommandExecute()
        {
            var plainPassword = this.convertToUNSecureString(this.Password);
            this.LoginOK = (this.Username == "user" && plainPassword == "pwd");

            var msg = new ShowDialogMessage();

            if (this.LoginOK == true)
            {
                msg.Title = Vocabulary.LoginSuccessfulTitle;
                msg.Content = Vocabulary.LoginSuccessfulText;
                msg.Icon = "Information";
            }
            else
            {
                msg.Title = Vocabulary.LoginFailedTitle;
                msg.Content = Vocabulary.LoginFailedText;
            }

            Messenger.Default.Send<ShowDialogMessage>(msg);
        }

        public string convertToUNSecureString(SecureString secstrPassword)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secstrPassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}