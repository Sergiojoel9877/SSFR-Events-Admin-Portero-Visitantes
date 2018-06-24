using SSFR_Events.Services;
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
        public static HttpClient Oauthclient { get; set; }

        public static HttpClient client { get; set; } = new HttpClient();

        public static SSFRClient ssfrClient { get; set; } = new SSFRClient(client);

        public static APIServices _APIServices { get; set; } = new APIServices();

        public App()
		{
          
            InitializeComponent();

            Oauthclient = new HttpClient
            {

                BaseAddress = new Uri("http://ssfrouthapi-sergio.azurewebsites.net/")

            };

            MainPage = new NavigationPage(new PostSplash());
            
        }

        protected override void OnStart ()
		{
            ContainerInitializer.Initialize(); //Moved to the App.Xaml, for better performance..

            OneSignal.Current.StartInit("23fbe6ba-7814-4714-aa75-00a3480f5b68").EndInit();

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
