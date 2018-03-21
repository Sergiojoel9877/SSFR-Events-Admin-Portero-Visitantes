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
	public partial class AddEvent : ContentPage
	{
        AddEventViewModel ViewModel;

		public AddEvent ()
		{
			InitializeComponent ();

            ViewModel = new AddEventViewModel(Navigation);

            BindingContext = ViewModel;
            
		}
	}
}