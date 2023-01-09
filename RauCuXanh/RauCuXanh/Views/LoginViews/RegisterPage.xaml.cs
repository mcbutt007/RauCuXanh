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
    public partial class RegisterPage : ContentPage
    {
        RegisterViewModel _viewmodel;
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = _viewmodel = new RegisterViewModel(Navigation);
        }
    }
}