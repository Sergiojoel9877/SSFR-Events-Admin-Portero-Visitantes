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

        public static HttpClient client { get; set; }

        public static APIServices _APIServices;

        public App(IDBRepository repo)
		{
         
			InitializeComponent();

            repo = repository;

            _APIServices = new APIServices();

            client = new HttpClient
            {

                BaseAddress = new Uri("http://ssfrouthapi-sergio.azurewebsites.net/")
                //BaseAddress = new Uri("http://localhost:5000/")

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
