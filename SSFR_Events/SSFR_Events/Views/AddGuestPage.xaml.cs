using SSFR_Events.Models;
using SSFR_Events.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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

		public AddGuestPage (SSFR_Events.Services.Events evnt, Image barcode)
		{
			InitializeComponent ();

            ViewModel = new AddGuestViewModel(Navigation, evnt, barcode);
            
            BindingContext = ViewModel;

            //Img.Source = ImageSource.FromStream(() => new MemoryStream(@byte));
            
		}

        public AddGuestPage()
        {
                
        }
	}
}