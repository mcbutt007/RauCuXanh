﻿using RauCuXanh.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RauCuXanh.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterCompletedPage : ContentPage
    {
        public RegisterCompletedPage()
        {
            InitializeComponent();
            BindingContext = new RegisterCompletedViewModel(Navigation);
        }
    }
}