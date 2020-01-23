using System;
using piu_tools.Models;
using piu_tools.Services;

namespace piu_tools.ViewModels
{
    public class UnlockableChartsViewModel : BaseViewModel
    {
        public string SearchText { get; set; }
        public MusicInfo Musics { get; set; }

        public UnlockableChartsViewModel()
        {
            Title = "Charts Desbloqueáveis";

            GetSongs();
        }

        private void GetSongs()
        {
            JSONHandler.GetSongListFromJson();
        }
    }
}
