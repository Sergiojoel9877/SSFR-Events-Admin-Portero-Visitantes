using Plugin.Connectivity;
using SSFR_Events.Data;
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
	public partial class LoginPage : ContentPage
	{
        LoginPageViewModel ViewModel;

		public LoginPage ()
		{
			InitializeComponent ();

            //ViewModel = new LoginPageViewModel(Navigation);
            ViewModel = ((ViewModelLocator)Application.Current.Resources["Locator"]).LoginViewModel;

            BindingContext = ViewModel;
            
        }

        void OnTapCheckBox(View view, object s)
        {
            if (ViewModel.IsChecked == false)
            {
                ViewModel.IsChecked = true;
            }
            else
            {
                ViewModel.IsChecked = false;
            }
        }
    }
}