﻿using SSFR_Events.Services;
using SSFR_Events.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Xamarin.Forms;

namespace SSFR_Events
{
	public partial class App : Application
	{
        public static IDBRepository repository;

        public static HttpClient client;

        public App(IDBRepository repo)
		{
         
			InitializeComponent();

            repo = repository;

            client = new HttpClient
            {

                BaseAddress = new Uri("http://oauthsfapi2018sergio.azurewebsites.net/")

            };

            var loginPage = new NavigationPage(new LoginPage())
            {
                BarTextColor = Color.FromHex("#FFA500")
            };

            MainPage = loginPage;

		}

        public App()
        {

        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
