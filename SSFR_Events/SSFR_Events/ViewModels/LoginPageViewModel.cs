using SSFR_Events.Views;
using System;
using System.Collections.Generic;
using SSFR_Events.Helpers;
using System.Text;
using Xamarin.Forms;
using SSFR_Events.Services;
using System.Security.Claims;
using System.Net.Http;

namespace SSFR_Events.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigation _navService;

        private Command login;
        public Command Login
        {
            get => login ?? (login = new Command(async () =>
            {

                var logged = await App._APIServices.LoginAsync(Email, Password, false);

                if(logged != null)
                {

                    Settings.Token = logged;

                    HttpClient clnt = new HttpClient();

                    clnt.BaseAddress = new Uri("http://ssfrouthapi-sergio.azurewebsites.net/");

                    clnt.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Settings.Token);

                    App.Oauthclient = null;

                    App.Oauthclient = clnt;
                    
                    var claims = await App._APIServices.GetUserClaims();

                    DependencyService.Get<IToast>().LongAlert(Settings.Token);

                    Settings.UserName = Email;

                    Settings.Password = password;

                    await _navService.PushModalAsync(new MainMasterDetailPage());
                    
                }
                else
                {
                    DependencyService.Get<IAlert>().Alert("Error", "Al parecer a ocurrido un error al momento de iniciar sesion, por favor intenta nuevamente.");
                }
            })); 
        }

        private string email;
        public string Email
        {
            get => email;

            set => SetProperty(ref email, value);
        }

        private string password;
        public string Password
        {
            get => password;

            set => SetProperty(ref password, value);

        }

        private bool isChecked = false;
        public bool IsChecked
        {
            get => isChecked;

            set => SetProperty(ref isChecked, value);
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

            Email = Settings.UserName;

            Password = Settings.Password;

        }
    }
}
