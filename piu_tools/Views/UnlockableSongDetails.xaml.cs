﻿using System;
using System.Collections.Generic;
using piu_tools.Models;
using piu_tools.ViewModels;
using Xamarin.Forms;

namespace piu_tools.Views
{
    public partial class UnlockableSongDetails : ContentPage
    {
        public UnlockableSongDetails(MusicInfo music)
        {
            InitializeComponent();
            BindingContext = new UnlockableSongDetailsViewModel(music);
        }

        protected override void OnAppearing()
        {
            
        }
    }
}
