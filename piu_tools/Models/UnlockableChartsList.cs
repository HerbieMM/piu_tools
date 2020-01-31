using System;
using System.Collections.Generic;
using Realms;

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
