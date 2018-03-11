using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SSFR_Events.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {
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

            get => register ?? (register = new Command( () => {


            }));
        }
    }
}
