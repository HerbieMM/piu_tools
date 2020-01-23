using System;
using System.Collections.Generic;

namespace piu_tools.Models
{
    public class MusicInfo
    {
        public string SongTitle { get; set; }
        public string SongArtist { get; set; }
        public List<Chart> Charts { get; set; }

        public MusicInfo()
        {}
    }
}
