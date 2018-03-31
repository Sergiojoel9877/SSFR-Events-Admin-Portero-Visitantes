using SSFR_Events.Services;
using SSFR_Events.Models;
using SSFR_Events.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;

namespace SSFR_Events.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {

        private readonly INavigation _navService;

        public ObservableCollection<string> RoleList { get; set; } = new ObservableCollection<string>();

        private bool empty = true;
        public bool Empty {

            get => empty;

            set => SetProperty(ref empty, value);

        }

        private bool admin = false;
        public bool Admin {

            get => admin;

            set => SetProperty(ref admin, value);

        }

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

        private string role;
        public string Role
        {
            get => role;

            set => SetProperty(ref role, value);
        }

        private string selectedRole;
        public string SelectedRole
        {
            get => selectedRole;

            set => SetProperty(ref selectedRole, value);
        }

        private Command register;
        public Command Register {

            get => register ?? (register = new Command( async () => 
            {
                if (NameEntry != null || ProfUser != null || Email != null || LastNameEntry != null || SelectedRole != null || ConfirmPassWord != null || PassWord != null || ConfirmPassWord == PassWord)
                {
                    Empty = false;

                    if (Empty == false)
                    {

                        var usersList = await DependencyService.Get<IDBRepoInstance>().getInstance().GetUsers();
                        
                        var query = usersList.Any(U => U.Role == "Admin");
                       
                        if (SelectedRole == "Admin" && query)
                        {
                            DependencyService.Get<IAlert>().Alert("Ya exite un Administrador", "Lo siento, ya exite un administrador.");

                            await _navService.PopAsync();
                        }
                        else
                        {
                            if (Email.Contains("@"))
                            {

                                var registrado = await _APIServices.RegisterAsync(Email, PassWord, ConfirmPassWord);

                                if (registrado)
                                {

                                    User user = new User()
                                    {
                                        LastName = LastNameEntry,
                                        Name = NameEntry,
                                        Pass = PassWord,
                                        ProfUser = ProfUser,
                                        Role = SelectedRole
                                    };


                                    if (user.Pass != null)
                                    {

                                        var r = await DependencyService.Get<IDBRepoInstance>().getInstance().AddUser(user);

                                        if (r)
                                        {
                                            DependencyService.Get<IAlert>().Alert("Registrado exitosamente", "Registrado exitosamente");

                                            await _navService.PopAsync();

                                        }
                                    }
                                }
                                else
                                {
                                    DependencyService.Get<IAlert>().Alert("ERROR", "Error: Asegurate de que tienes conexión a internet, e intentalo de nuevo " + registrado.ToString());
                                }
                            }
                            else
                            {
                                DependencyService.Get<IAlert>().Alert("ERROR", "Error el correo no es valido");
                            }
                        }
                    }
                    else
                    {
                        DependencyService.Get<IAlert>().Alert("Error", "No puedes dejar campos vacios, y/o las contraseña no son iguales, intenta una vez mas.");
                    }

                }
                else
                {
                    DependencyService.Get<IAlert>().Alert("Error", "No puedes dejar campos vacios, y/o las contraseña no son iguales, intenta una vez mas.");
                }
            }));
        }

        void AddRoles()
        {
            string Admin = "Admin";

            string Portero = "Portero";

            RoleList.Add(Admin);

            RoleList.Add(Portero);
        }

        public RegisterPageViewModel(INavigation navService)
        {

            _navService = navService;

            AddRoles();

        }
    }
}
