using SSFR_Events.Models;
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
	public partial class AddGuestPage : ContentPage
	{
        AddGuestViewModel ViewModel;

		public AddGuestPage (SSFR_Events.Services.Events evnt)
		{
			InitializeComponent ();

            ViewModel = new AddGuestViewModel(Navigation, evnt);
            
            BindingContext = ViewModel;
		}

        public AddGuestPage()
        {
                
        }
	}
}