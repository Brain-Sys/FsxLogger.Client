using FsxLogger.ViewModels.Messages;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System;

namespace FsxLogger.Client
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Messenger.Default.Register<CloseApplicationMessage>(this, closeApplicationMessage);
            Messenger.Default.Register<ShowDialogMessage>(this, showDialogMessage);

            base.OnStartup(e);
        }

        private void showDialogMessage(ShowDialogMessage obj)
        {
            MessageBoxImage icon = (MessageBoxImage)Enum.Parse(typeof(MessageBoxImage), obj.Icon);
            MessageBox.Show(obj.Content, obj.Title, MessageBoxButton.OK, icon);
        }

        private void closeApplicationMessage(CloseApplicationMessage obj)
        {
            Application.Current.Shutdown();
        }
    }
}