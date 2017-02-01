using FsxLogger.ViewModels.Messages;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace FsxLogger.Client
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Messenger.Default.Register<CloseApplicationMessage>(this, closeApplicationMessage);

            base.OnStartup(e);
        }

        private void closeApplicationMessage(CloseApplicationMessage obj)
        {
            Application.Current.Shutdown();
        }
    }
}