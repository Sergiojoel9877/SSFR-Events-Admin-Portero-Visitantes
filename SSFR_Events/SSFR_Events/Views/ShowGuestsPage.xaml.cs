using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSFR_Events.Data;
using SSFR_Events.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SSFR_Events.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShowGuestsPage : ContentPage
	{
        ShowGuestsViewModel vm;
		public ShowGuestsPage ()
		{
			InitializeComponent ();

            vm = ((ViewModelLocator)Application.Current.Resources["Locator"]).ShowGuestsViewModel;

            BindingContext = vm;
		}
	}
}