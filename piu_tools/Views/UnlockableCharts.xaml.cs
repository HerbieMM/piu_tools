using System;
using System.Collections.Generic;
using piu_tools.ViewModels;
using Xamarin.Forms;

namespace piu_tools.Views
{
    public partial class Unlockable : ContentPage
    {
        public Unlockable()
        {
            InitializeComponent();
            BindingContext = new UnlockableChartsViewModel();
        }
    }
}
