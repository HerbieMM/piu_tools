using System;
using System.Collections.ObjectModel;
using System.Linq;
using piu_tools.Models;
using piu_tools.Views;
using Xamarin.Forms;

namespace piu_tools.ViewModels
{
    public class UnlockableSongDetailsViewModel : BaseViewModel
    {
        #region [ Properties ]
        private MusicInfo music;

        private string songBanner;
        public string SongBanner
        {
            get { return songBanner; }
            set
            {
                songBanner = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Chart> singlesList;
        public ObservableCollection<Chart> SinglesList
        {
            get { return singlesList; }
            set
            {
                singlesList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Chart> doublesList;
        public ObservableCollection<Chart> DoublesList
        {
            get { return doublesList; }
            set
            {
                doublesList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Chart> coopsList;
        public ObservableCollection<Chart> CoopsList
        {
            get { return coopsList; }
            set
            {
                coopsList = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public UnlockableSongDetailsViewModel()
        { }

        public UnlockableSongDetailsViewModel(MusicInfo selectedMusic)
        {
            Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Wait...");

            music = selectedMusic;

            Title = selectedMusic.SongTitle;
            SongBanner = selectedMusic.SongBanner;            

            var allCharts = MusicDataStore.GetChartsItem(selectedMusic.SongId);

            var singles = allCharts.Where(s => s.Level.Contains("S"));
            var doubles = allCharts.Where(s => s.Level.Contains("D"));
            var coops = allCharts.Where(s => s.Level.Contains("CO-OP"));

            SinglesList = new ObservableCollection<Chart>(singles);
            DoublesList = new ObservableCollection<Chart>(doubles);
            CoopsList = new ObservableCollection<Chart>(coops);

            MessagingCenter.Subscribe<UnlockableSongDetails>(this, "Checkbock value changed!", (sender) =>
            {
                UpdateAllCharts();
            });

            Acr.UserDialogs.UserDialogs.Instance.HideLoading();
        }

        private void UpdateAllCharts()
        {
            var charts = SinglesList.Concat(DoublesList).Concat(CoopsList);
            music.Charts = new ObservableCollection<Chart>(charts);

            MusicDataStore.UpdateItemAsync(music);

            Acr.UserDialogs.UserDialogs.Instance.Toast("Success!");
        }
    }
}
