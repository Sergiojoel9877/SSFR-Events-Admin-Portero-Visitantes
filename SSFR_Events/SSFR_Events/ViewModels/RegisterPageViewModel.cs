using Mobile.SSFR_Events.Services;
using SSFR_Events.Models;
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
        public string LastNameEntry
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

                if (ProfUser != String.Empty || NameEntry != String.Empty || Email != String.Empty || LastNameEntry != String.Empty || (ConfirmPassWord == PassWord) || (PassWord == ConfirmPassWord))
                {

                    if (Email.Contains("@")) 
                    {

                        var registrado = await _APIServices.RegisterAsync(Email, PassWord, ConfirmPassWord);

                        if (registrado)
                        {

                            User user = new User() { LastName = LastNameEntry, Name = NameEntry, Pass = PassWord, ProfUser = ProfUser };

                            if (user.Pass != null)
                            {

                                //var r = await App.repository.AddUser(user);
                                var r = DependencyService.Get<IDBRepoInstance>().getInstance().AddUser(user).Result;

                                if (r)
                                {
                                    DependencyService.Get<IAlert>().Alert("Registrado exitosamente", "Registrado exitosamente");

                                   await _navService.PopAsync();

                                }
                            }
                        }
                        else
                        {
                            DependencyService.Get<IAlert>().Alert("ERROR", "Error: " + registrado.ToString());
                        }
                    }
                }
                else
                {
                    DependencyService.Get<IAlert>().Alert("Error", "No puedes dejar campos vacios, y/o las contraseña no son iguales");
                }
            }));
        }

        public RegisterPageViewModel(INavigation navService)
        {

            _navService = navService;

        }
    }
}
