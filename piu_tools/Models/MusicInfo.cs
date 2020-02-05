using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite;

namespace piu_tools.Models
{
    public class MusicInfo
    {
        [PrimaryKey]
        public string SongId { get; set; }
        public string SongTitle { get; set; }
        public string SongArtist { get; set; }
        public string SongBanner { get; set; }

        [Ignore]
        public ObservableCollection<Chart> Charts { get; set; }

        public MusicInfo() : this(string.Empty, string.Empty, string.Empty, string.Empty)
        { }

        public MusicInfo(string songId, string songTitle, string songArtist, string songBanner)
        {
            SongId = songId;
            SongTitle = songTitle;
            SongArtist = songArtist;
            SongBanner = songBanner;
        }
    }
}


