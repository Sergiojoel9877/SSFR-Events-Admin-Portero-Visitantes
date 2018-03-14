using SSFR_Events.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SSFR_Events.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigation _navService;

        private Command login;
        public Command Login
        {
            get => login ?? (login = new Command(() => {

            _navService.PushModalAsync(new MainMasterDetailPage());

            })); 
        }

        private Command register;
        public Command Register
        {

            get => register ?? (register = new Command(() => 
            {

                _navService.PushAsync(new RegisterPage());
                
            }));
        }

        public LoginPageViewModel(INavigation navService)
        {
            _navService = navService;
        }
    }
}
