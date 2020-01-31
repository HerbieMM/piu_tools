using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Realms;

namespace piu_tools.Models
{
    public class MusicInfo
    {
        public string SongId { get; set; }

        public string SongTitle { get; set; }
        public string SongArtist { get; set; }
        public string SongBanner { get; set; }
        public List<Chart> Charts { get; set; }

        public MusicInfo()
        {}
    }
}


