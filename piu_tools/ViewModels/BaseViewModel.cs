using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using piu_tools.Models;
using piu_tools.Services;

namespace piu_tools.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<MusicInfo> MusicDataStore => DependencyService.Get<IDataStore<MusicInfo>>();
        public IDataStore<Chart> ChartDataStore => DependencyService.Get<IDataStore<Chart>>();
        public IDataStore<ChartUnlockRequirements> ChartUnlockRequirementsDataStore => DependencyService.Get<IDataStore<ChartUnlockRequirements>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
