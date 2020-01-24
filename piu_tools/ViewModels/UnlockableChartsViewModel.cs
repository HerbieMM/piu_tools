using System;
using System.Collections.ObjectModel;
using System.Linq;
using piu_tools.Models;
using piu_tools.Services;

namespace piu_tools.ViewModels
{
    public class UnlockableChartsViewModel : BaseViewModel
    {        
        public string Title
        {
            get { return "Charts Desbloqueáveis"; }
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
        
        public ObservableCollection<MusicInfo> musicsList { get; set; }
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
        
        public UnlockableChartsViewModel()
        {
            GetSongs();
        }

        private void GetSongs()
        {
            var musics = JSONHandler.GetSongListFromJson();

            DefaultMusicsList = musics;
            MusicsList = musics;
        }
    }
}
