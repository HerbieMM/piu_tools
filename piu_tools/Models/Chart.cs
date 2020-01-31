﻿
using System.Collections.Generic;
using Realms;

namespace piu_tools.Models
{
    public class Chart
    {

        public string SongId { get; set; }
        public string ChartId { get; set; }

        public bool Done { get; set; }
        public string Level { get; set; }
        public List<ChartUnlockRequirements> Require { get; set; }

        public Chart()
        {
        }
    }
}
