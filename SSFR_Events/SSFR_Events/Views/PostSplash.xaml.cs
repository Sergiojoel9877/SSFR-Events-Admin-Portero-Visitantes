﻿
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SSFR_Events.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PostSplash : ContentPage
	{
		public PostSplash ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Splash.ScaleTo(1, 2000);
            await Splash.ScaleTo(0.8, 1500, Easing.Linear);
            await Splash.ScaleTo(40, 1000, Easing.Linear);
            await Splash.FadeTo(20, 1000, Easing.Linear);
            await Splash.FadeTo(0, 1000, Easing.Linear);
            await Splash.ScaleTo(150, 700, Easing.Linear);

            var loginPage = new NavigationPage(new LoginPage())
            {

                BarTextColor = Color.FromHex("#FFA500")

            };

            Application.Current.MainPage = loginPage;
        }
        
    }
}