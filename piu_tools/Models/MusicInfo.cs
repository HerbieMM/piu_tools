using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace piu_tools.Models
{
    public class MusicInfo
    {
        public string SongTitle { get; set; }
        public string SongArtist { get; set; }
        public string SongBanner { get; set; }
        public ObservableCollection<Chart> Charts { get; set; }

        public MusicInfo()
        {}
    }
}
