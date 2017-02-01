using GalaSoft.MvvmLight;
using System;

namespace FsxLogger.ViewModels.Portable
{
    public abstract class ApplicationViewModelBase : ViewModelBase
    {
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value;
                base.RaisePropertyChanged();
            }
        }
    }
}