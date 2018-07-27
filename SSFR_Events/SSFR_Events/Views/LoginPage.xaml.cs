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

            PushToRegisterPage();
            
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

        void PushToRegisterPage()
        {
            MessagingCenter.Subscribe<LoginPageViewModel, RegisterPage>(this, "PushToRegisterPage", (s, e) =>
            {
                Navigation.PushAsync(e);
            });
        }
    }
}