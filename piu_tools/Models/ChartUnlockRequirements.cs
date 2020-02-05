
using System;
using System.ComponentModel;
using piu_tools.Services;
using SQLite;

namespace piu_tools.Models
{
    public class ChartUnlockRequirements
    {
        [PrimaryKey]
        public string RequirementId { get; set; }
        public string ChartId { get; set; }
        public bool Done { get; set; }
        public string Description { get; set; }

        public ChartUnlockRequirements() : this(string.Empty, false, string.Empty, string.Empty)
        { }

        public ChartUnlockRequirements(string chartId, bool done, string description, string requirementId)
        {
            ChartId = chartId;
            Done = done;
            Description = description;
            RequirementId = requirementId;
        }
    }
}