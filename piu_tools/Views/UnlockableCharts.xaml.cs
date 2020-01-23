using System;
using System.Collections.Generic;
using piu_tools.ViewModels;
using Xamarin.Forms;

namespace piu_tools.Views
{
    public partial class UnlockableCharts : ContentPage
    {
        public UnlockableCharts()
        {
            InitializeComponent();
            BindingContext = new UnlockableChartsViewModel();
        }
    }
}
