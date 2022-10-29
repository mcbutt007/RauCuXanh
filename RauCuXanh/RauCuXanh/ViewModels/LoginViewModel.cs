﻿using RauCuXanh.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RauCuXanh.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginBtn { get; }
        public Command ForgetPasswordBtn { get; }
        public Command RegisterBtn { get; }
        public INavigation Navigation { get; set; }

        public LoginViewModel(INavigation navigation)
        {
            Navigation = navigation;
            LoginBtn = new Command(async() => await OnLoginClicked());
            ForgetPasswordBtn = new Command(async() => await OnForgetPasswordClicked());
            RegisterBtn = new Command(async() => await OnRegisterClicked());
        }

        private async Task OnRegisterClicked()
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async Task OnForgetPasswordClicked()
        {
            await Navigation.PushAsync(new ForgetPasswordPage());
        }

        private async Task OnLoginClicked()
        {
            await Navigation.PushAsync(new CheckingPage());
        }
    }
}
