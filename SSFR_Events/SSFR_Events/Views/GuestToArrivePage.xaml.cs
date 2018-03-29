using SSFR_Events.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SSFR_Events.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GuestToArrivePage : ContentPage
	{

        GuestToArriveViewModel ViewModel;

		public GuestToArrivePage ()
		{
			InitializeComponent ();

            ViewModel = new GuestToArriveViewModel(Navigation);

            BindingContext = ViewModel;

		}

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopModalAsync();

            Navigation.PushModalAsync(new MainMasterDetailPage());

            base.OnBackButtonPressed();

            return true;

        }
	}
}