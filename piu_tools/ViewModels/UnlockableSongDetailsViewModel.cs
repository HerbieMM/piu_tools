using System;
using piu_tools.Models;

namespace piu_tools.ViewModels
{
    public class UnlockableSongDetailsViewModel : BaseViewModel
    {
        private MusicInfo selectedMusic;
        public MusicInfo SelectedMusic
        {
            get { return selectedMusic; }
            set
            {
                selectedMusic = value;
                OnPropertyChanged();
            }
        }
        
        public UnlockableSongDetailsViewModel()
        {
        }
        
        public UnlockableSongDetailsViewModel(MusicInfo selectedMusic)
        {
            SelectedMusic = selectedMusic;
        }


    }
}
