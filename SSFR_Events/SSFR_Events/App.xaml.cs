using SSFR_Events.Services;
using SSFR_Events.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SSFR_Events
{
	public partial class App : Application
	{
        public static IDBRepository repository;

		public App (IDBRepository repo)
		{
         
			InitializeComponent();

            repo = repository;

			MainPage = new NavigationPage(new LoginPage());

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
