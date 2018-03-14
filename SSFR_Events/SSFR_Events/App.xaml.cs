using Mobile.SSFR_Events.Services;
using SSFR_Events.Services;
using SSFR_Events.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Unity;
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

            client = new HttpClient {

                BaseAddress = new Uri("http://oauthssfrapi.azurewebsites.net")

            };
        
			MainPage = new NavigationPage(new LoginPage());

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
