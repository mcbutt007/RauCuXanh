﻿using RauCuXanh.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RauCuXanh.ViewModels
{
    public class CheckingScreenViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        public CheckingScreenViewModel(INavigation navigation)
        {
            Navigation = navigation;
            //move logic to CheckingScreen.xaml.cs
            //CheckAndNavigate();
        }

        //private void CheckAndNavigate()
        //{
        //    Navigation.PushAsync(new AppShell());
        //    App.Current.MainPage = new AppShell();
        //}
    }
}
