
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

           

            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
        
    }
}