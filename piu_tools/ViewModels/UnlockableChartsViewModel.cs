using System;
using System.Collections.ObjectModel;
using System.Linq;
using piu_tools.Models;
using piu_tools.Services;
using piu_tools.Views;
using Xamarin.Forms;

namespace piu_tools.ViewModels
{
    public class UnlockableChartsViewModel : BaseViewModel
    {
        #region [ Properties ]

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        
        private ObservableCollection<MusicInfo> defaultMusicsList;
        public ObservableCollection<MusicInfo> DefaultMusicsList
        {
            get { return defaultMusicsList; }
            set
            {
                defaultMusicsList = value;
                OnPropertyChanged();
            }
        }
        
        private ObservableCollection<MusicInfo> musicsList { get; set; }
        public ObservableCollection<MusicInfo> MusicsList
        {
            get {
                return musicsList;
            }
            set {
                musicsList = value;
                OnPropertyChanged();
            }
        }
               
        private MusicInfo selectedMusic;
        public MusicInfo SelectedMusic
        {
            get { return selectedMusic; }
            set {
                selectedMusic = value;
                OnPropertyChanged();

                GoToSongInfo(value);
            }
        }

        private string searchText { get; set; }
        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                searchText = value;
                OnPropertyChanged();

                if (searchText.Count() > 0)
                {
                    var list = MusicsList.Where(c => c.SongTitle.ToLower().Contains(searchText.ToLower())).ToList();

                    MusicsList = new ObservableCollection<MusicInfo>(list);
                }
                else
                {
                    MusicsList = DefaultMusicsList;
                }
            }
        }
        
        #endregion
        
        public UnlockableChartsViewModel()
        {
            Title = "Unlockable Charts";

            Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Aguarde...");

            GetSongs();

            Acr.UserDialogs.UserDialogs.Instance.HideLoading();

        }

        private void GetSongs()
        {
            var musics = JSONHandler.GetSongListFromJson();

            DefaultMusicsList = musics;
            MusicsList = musics;
        }

        private async void GoToSongInfo(MusicInfo selectedMusic)
        {
            await NavigationService.PushAsync(new UnlockableSongDetails(selectedMusic));            
        }
    }
}
