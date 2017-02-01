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
            set { username = value;
                base.RaisePropertyChanged();
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value;
                base.RaisePropertyChanged();
            }
        }

        public LoginViewModel()
        {
            this.Username = "igor";
            this.Password = "pwd";
        }
    }
}