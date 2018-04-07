﻿using SSFR_Events.Views;
using System;
using System.Collections.Generic;
using SSFR_Events.Helpers;
using System.Text;
using Xamarin.Forms;
using SSFR_Events.Services;
using System.Security.Claims;
using System.Net.Http;

namespace SSFR_Events.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigation _navService;

        private Command login;
        public Command Login
        {
            get => login ?? (login = new Command(async () =>
            {

                var logged = await App._APIServices.LoginAsync(Email, Password, false);

                Settings.Token = logged;

                HttpClient clnt = new HttpClient();

                clnt.BaseAddress = new Uri("http://ssfrouthapi-sergio.azurewebsites.net/");

                clnt.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Settings.Token);

                App.client = null;

                App.client = clnt;

                if (logged != null)
                {

                    var claims = await App._APIServices.GetUserClaims();

                    DependencyService.Get<IToast>().LongAlert(logged.ToString());

                    Email = Settings.UserName;

                    Password = Settings.Password;

                    await _navService.PushModalAsync(new MainMasterDetailPage());
                }
                
            })); 
        }

        private string email;
        public string Email
        {
            get => email;

            set => SetProperty(ref email, value);
        }

        private string password;
        public string Password
        {
            get => password;

            set => SetProperty(ref password, value);

        }

        private bool isChecked = false;
        public bool IsChecked
        {
            get => isChecked;

            set => SetProperty(ref isChecked, value);
        }

        private Command register;
        public Command Register
        {

            get => register ?? (register = new Command(() => 
            {

                _navService.PushAsync(new RegisterPage());
                
            }));
        }

        public LoginPageViewModel(INavigation navService)
        {
            _navService = navService;

            Email = Settings.UserName;

            Password = Settings.Password;

        }
    }
}
