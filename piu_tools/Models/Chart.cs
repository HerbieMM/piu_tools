using System;
using System.Collections.Generic;

namespace piu_tools.Models
{
    public class Chart
    {
        public bool Done { get; set; }
        public string Level { get; set; }
        public List<ChartUnlockRequirements> Require { get; set; }

        public Chart()
        {
        }
    }
}
