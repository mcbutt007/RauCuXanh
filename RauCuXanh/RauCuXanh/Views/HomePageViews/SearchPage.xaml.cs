﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RauCuXanh.ViewModels.HomePageViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RauCuXanh.Views.HomePageViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        SearchViewModel _viewmodel;
        public SearchPage()
        {
            InitializeComponent();
            BindingContext = _viewmodel = new SearchViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Shell.SetNavBarIsVisible(this, false);
        }
    }
}