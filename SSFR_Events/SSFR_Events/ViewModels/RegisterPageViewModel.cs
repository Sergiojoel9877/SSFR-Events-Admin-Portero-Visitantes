using SSFR_Events.Services;
using SSFR_Events.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SSFR_Events.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {

        private readonly INavigation _navService;

        private APIServices _APIServices = new APIServices();
        
        private string nameEntry;
        public string NameEntry
        {
            get => nameEntry;

            set => SetProperty(ref nameEntry, value);
        }

        private string lastNameEntry;
        public string LastEntry
        {
            get => lastNameEntry;

            set => SetProperty(ref lastNameEntry, value);
        }

        private string profUser;
        public string ProfUser
        {
            get => profUser;

            set => SetProperty(ref profUser, value);
        }

        private string email;
        public string Email
        {
            get => email;

            set => SetProperty(ref email, value);
        }

        private string passWord;
        public string PassWord
        {
            get => passWord;

            set => SetProperty(ref passWord, value);
        }

        private string confirmPassWord;
        public string ConfirmPassWord
        {
            get => confirmPassWord;

            set => SetProperty(ref confirmPassWord, value);
        }

        private Command register;
        public Command Register {

            get => register ?? (register = new Command( async () => 
            {

                await _APIServices.RegisterAsync(Email, PassWord, ConfirmPassWord);

            }));
        }

        public RegisterPageViewModel(INavigation navService)
        {

            _navService = navService;

        }
    }
}
