using System;
using System.Collections.Generic;

namespace piu_tools.Models
{
    public class UnlockableChartsList
    {
        public string Version { get; set; }
        public List<MusicInfo> Musics { get; set; }

        public UnlockableChartsList()
        {
        }
    }
}
