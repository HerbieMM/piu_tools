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

        private MusicInfo musicApi;
        private ObservableCollection<MusicInfo> DefaultMusicInfo;

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
        
        private string searchText { get; set; }
        public string SearchText {
            get {
                return searchText;
            }
            set {
                searchText = value;
                OnPropertyChanged();

                if (searchText.Count() > 0) {
                    var list = MusicsList.Where(c => c.SongTitle.ToLower().Contains(searchText.ToLower())).ToList();

                    MusicsList = new ObservableCollection<MusicInfo>(list);
                }
                else
                {
                    MusicsList = DefaultMusicInfo;
                }
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

        public UnlockableChartsViewModel()
        {            

            GetSongs();
        }

        private void GetSongs()
        {
            var musics = JSONHandler.GetSongListFromJson();

            DefaultMusicInfo = musics;
            MusicsList = musics;
        }
    }
}
