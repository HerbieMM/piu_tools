
using System;
using System.ComponentModel;

namespace piu_tools.Models
{
    public class ChartUnlockRequirements : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string ChartId { get; set; }

        private bool _done;

        public ChartUnlockRequirements()
        {
        }

        public bool Done
        {
            get { return _done; }
            set
            {
                _done = value;
                UpdateDataBase();
            }
        }

        private void UpdateDataBase()
        {
           
        }

        public string Description { get; set; }

    }
}