
using System.Collections.Generic;
using System.ComponentModel;
using SQLite;

namespace piu_tools.Models
{
    public class Chart
    {
        [PrimaryKey]
        public string SongId { get; set; }
        
        public string ChartId { get; set; }

        private bool _done;
        public bool Done
        {
            get
            {
                return _done;
            }
            set
            {
                _done = value;

            }
        }

        public string Level { get; set; }
        public List<ChartUnlockRequirements> Require { get; set; }

        public Chart()
        {
        }
    }
}


