﻿using RauCuXanh.Models;
using RauCuXanh.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XF.Material.Forms.Models;
using XF.Material.Forms.UI;
using XF.Material.Forms.UI.Dialogs;

namespace RauCuXanh.ViewModels
{
    public class PersonalInformationViewModel : BaseViewModel
    {
        public List<string> Genderlist { get; set; }
        public Command LoadUserDetail { get; set; }
        public Command UpdateCommand { get; set; }
        public ICommand ChangeGenderCommand => new Command<MaterialMenuResult>((s) => GenderSelected(s));

        private void GenderSelected(MaterialMenuResult i)
        {
            switch (i.Index)
            {
                case 0:
                    {
                        Gender = "male";
                        break;
                    }
                case 1:
                    {
                        Gender = "female";
                        break;
                    }
            }
        }

        private User _user;
        public User User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }
        private string _profilepic = string.Empty;
        public string Profile_pic { get => _profilepic; set { SetProperty(ref _profilepic, value); } }

        private string _username = string.Empty;
        public string Username { get => _username; set { SetProperty(ref _username, value); } }

        private string _email = string.Empty;
        public string Email { get => _email; set { SetProperty(ref _email, value); } }

        private string _phone = string.Empty;
        public string Phone { get => _phone; set { SetProperty(ref _phone, value); } }

        private string _birthday = string.Empty;
        public string Birthday { get => _birthday; set { SetProperty(ref _birthday, value); } }

        private string _gender = string.Empty;
        public string Gender { get => _gender; set { SetProperty(ref _gender, value); } }

        public PersonalInformationViewModel()
        {
            Genderlist = new List<string> { "male", "female" };
            LoadUserDetail = new Command(async () => await LoadUserInfo());
            Title = "Thông tin cá nhân";
            UpdateCommand = new Command(ExeUpdateCommand);
        }

        public async Task LoadUserInfo()
        {
            IsBusy = true;
            try
            {
                var apiClient = RestService.For<IUserApi>(RestClient.BaseUrl);
                var user = await apiClient.GetUserById(userid);
                User = user;
                Profile_pic = string.IsNullOrEmpty(user.Profile_pic) ? "profile.png" : user.Profile_pic;
                Username = user.Username;
                Email = user.Email;
                Phone = user.Phone_no ?? string.Empty;
                Birthday = user.Birthday ?? DateTime.Today.ToString();
                Gender = user.Gender ?? string.Empty;
            }
            catch (Exception ex)
            {
                await MaterialDialog.Instance.AlertAsync(message: ex.Message);
            }
            finally { IsBusy = false; }
        }

        public async void ExeUpdateCommand()
        {
            try
            {
                var userService = RestService.For<IUserApi>(RestClient.BaseUrl);
                var response = await userService.UpdateUser(userid, new User()
                {
                    Profile_pic = Profile_pic,
                    Username = Username,
                    Email = Email,
                    Phone_no = Phone,
                    Gender = Gender,
                    Birthday = DateTime.Parse(Birthday).ToString("MM-dd-yyyy")
                });

                if (response.IsSuccessStatusCode)
                {
                    await MaterialDialog.Instance.SnackbarAsync(message: "Cập nhật thành công.", actionButtonText: "OK",
                                            msDuration: MaterialSnackbar.DurationShort);
                    IsBusy = true;
                }
                else
                {
                    await MaterialDialog.Instance.AlertAsync(message: response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                await MaterialDialog.Instance.AlertAsync(message: ex.Message);
            }

        }

        internal void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
