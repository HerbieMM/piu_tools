
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SQLite;

namespace piu_tools.Models
{
    public class Chart
    {        
        public string SongId { get; set; }

        [PrimaryKey]        
        public string ChartId { get; set; }

        public string Done { get; set; }

        public string Level { get; set; }

        [Ignore]
        public ObservableCollection<ChartUnlockRequirements> Require { get; set; }

        public Chart() : this(string.Empty, string.Empty, string.Empty, string.Empty, new ObservableCollection<ChartUnlockRequirements>())
        {}

        public Chart(string songId, string chartId, string done, string level, ObservableCollection<ChartUnlockRequirements> require)
        {
            SongId = songId;
            ChartId = chartId;
            Done = done;
            Level = level;
            Require = require;
        }
    }
}


