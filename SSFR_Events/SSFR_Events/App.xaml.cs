﻿using SSFR_Events.Services;
using SSFR_Events.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Com.OneSignal;

using Xamarin.Forms;
using Plugin.Connectivity;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter;

namespace SSFR_Events
{
	public partial class App : Application
	{
        public const string NotificationReceivedKey = "NotificationReceived";

        public const string MobileServiceUrl = "http://ssfrpushnotifications.azurewebsites.net";

        public static HttpClient Oauthclient { get; set; }

        public static HttpClient client { get; set; } = new HttpClient();

        public static SSFRClient ssfrClient { get; set; } = new SSFRClient(client);

        public static APIServices _APIServices { get; set; } = new APIServices();

        public App()
		{
          
            InitializeComponent();

            MainPage = new NavigationPage(new PostSplash());
            
        }

        protected override void OnStart ()
		{
            ContainerInitializer.Initialize(); //Moved to the App.Xaml, for better performance..

                Oauthclient = new HttpClient
                {

                    BaseAddress = new Uri("http://ssfrouthapi-sergio.azurewebsites.net/")

                };

                var loginPage = new NavigationPage(new LoginPage())
                {
                    BarTextColor = Color.FromHex("#FFA500")
                };

                OneSignal.Current.StartInit("23fbe6ba-7814-4714-aa75-00a3480f5b68").EndInit();

                MainPage = loginPage;

            }
            catch (Exception e)
            {
                var properties = new Dictionary<string, string>
                {
                    {"Message", e.Message },
                    {"Source", e.Source },
                    {"StackTrace", e.StackTrace }
                };
                Crashes.TrackError(e);
            }
        }

        protected override void OnStart ()
		{
            AppCenter.Start("android=dbb02fc3-6244-476e-a802-21da204eb894;", typeof(Analytics), typeof(Crashes));
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
