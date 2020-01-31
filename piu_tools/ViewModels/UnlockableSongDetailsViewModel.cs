using System;
using System.Collections.ObjectModel;
using System.Linq;
using piu_tools.Models;

namespace piu_tools.ViewModels
{
    public class UnlockableSongDetailsViewModel : BaseViewModel
    {
        #region [ Properties ]
        
        private MusicInfo selectedMusic;
        private string songBanner;

        private ObservableCollection<Chart> singlesList;
        private ObservableCollection<Chart> coopsList;
        private ObservableCollection<Chart> doublesList;

        public MusicInfo SelectedMusic
        {
            get { return selectedMusic; }
            set
            {
                selectedMusic = value;
                OnPropertyChanged();
            }
        }
        public string SongBanner
        {
            get { return songBanner; }
            set
            {
                songBanner = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Chart> SinglesList
        {
            get { return singlesList; }
            set
            {
                singlesList = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Chart> DoublesList
        {
            get { return doublesList; }
            set
            {
                doublesList = value;
                OnPropertyChanged();
            }
        }
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

            Title = selectedMusic.SongTitle;
            SelectedMusic = selectedMusic;
            


            var singles = selectedMusic.Charts.ToList().Where(s => s.Level.Contains("S"));
            var doubles = selectedMusic.Charts.ToList().Where(s => s.Level.Contains("D"));
            var coops = selectedMusic.Charts.ToList().Where(s => s.Level.Contains("CO-OP"));

            SinglesList = new ObservableCollection<Chart>(singles);
            DoublesList = new ObservableCollection<Chart>(doubles);
            CoopsList = new ObservableCollection<Chart>(coops);
        }
    }
}
