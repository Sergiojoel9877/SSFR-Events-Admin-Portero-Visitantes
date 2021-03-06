﻿using SSFR_Events.Services;
using SSFR_Events.Models;
using SSFR_Events.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using SSFR_Events.Helpers;
using System.Linq;
using Acr.UserDialogs;
using Plugin.Connectivity;
using CommonServiceLocator;

namespace SSFR_Events.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {

        DBRepository/*<User> */dbRepo;

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

        private string selectedRole = "";
        public string SelectedRole
        {
            get => selectedRole;

            set => SetProperty(ref selectedRole, value);
        }

        private Command register;
        public Command Register {

            get => register ?? (register = new Command( async () => 
            {
                try
                {
                    if (NameEntry != null && ProfUser != null && Email != null && LastNameEntry != null && SelectedRole != null && ConfirmPassWord != null && PassWord != null)
                    {

                        if (!CrossConnectivity.Current.IsConnected)
                        {
                            DependencyService.Get<IAlert>().Alert("Error", "Al parecer no tienes acceso a intenet.");
                            return;
                        }

                        IProgressDialog progresss = UserDialogs.Instance.Loading("Por favor espera", null, null, true, MaskType.Black);

                        Empty = false;

                        if (Empty == false)
                        {

                            if (SelectedRole == "Admin")
                            {
                                Settings.Role = SelectedRole;

                                if (Email.Contains("@"))
                                {

                                    var registrado = await App._APIServices.RegisterAsync(Email, PassWord, ConfirmPassWord);
                                    //var registrado = true;

                                    //if (registrado)
                                    if (registrado)
                                    {

                                        var user = new SSFR_Events.Services.User()
                                        {
                                            LastName = LastNameEntry,
                                            Name = NameEntry,
                                            Pass = PassWord,
                                            Email = Email,
                                            ProfUser = ProfUser,
                                            Role = SelectedRole
                                        };

                                        Settings.UserName = user.Email;

                                        Settings.Password = user.Pass;

                                        if (user.Pass != null && user.Pass == ConfirmPassWord)
                                        {
                                        /*1-)Replaced in favor of EF Core methods..*/

                                            var r = await App.ssfrClient.ApiUserPostAsync(user);

                                            //var r = await dbRepo.AddUser(user);

                                            progresss.Dispose();

                                            if (r)
                                            {

                                                DependencyService.Get<IAlert>().Alert("Registrado exitosamente", "Registrado exitosamente"/* + await dbRepo.GetUsers()*/);

                                                Device.BeginInvokeOnMainThread(() => {

                                                    Application.Current.MainPage.Navigation.PopAsync();

                                                });
                                                
                                            }
                                        }
                                        else
                                        {
                                            DependencyService.Get<IAlert>().Alert("Error", "Las contraseñas no son iguales.");

                                        }
                                    }
                                    else
                                    {
                                        progresss.Dispose();

                                        DependencyService.Get<IAlert>().Alert("ERROR", "Error: Asegurate de que tienes conexión a internet, e intentalo de nuevo " + registrado.ToString());
                                    }
                                }
                                else
                                {
                                    progresss.Dispose();
                                    DependencyService.Get<IAlert>().Alert("ERROR", "Error el correo no es valido");
                                }
                            }
                            else
                            {

                                Settings.Role = "";

                                if (Email.Contains("@"))
                                {


                                    var registrado = await App._APIServices.RegisterAsync(Email, PassWord, ConfirmPassWord);
                             
                                    if (registrado)
                                    {

                                        var user = new SSFR_Events.Services.User()
                                        {
                                            LastName = LastNameEntry,
                                            Name = NameEntry,
                                            Pass = PassWord,
                                            Email = Email,
                                            ProfUser = ProfUser,
                                            Role = SelectedRole
                                        };

                                        Settings.UserName = Email;

                                        Settings.Password = PassWord;

                                        if (user.Pass != null)
                                        {

                                            var r = await App.ssfrClient.ApiUserPostAsync(user);

                                            progresss.Dispose();

                                            if (r)
                                            {

                                                DependencyService.Get<IAlert>().Alert("Registrado exitosamente", "Registrado exitosamente");

                                                Device.BeginInvokeOnMainThread(() => {

                                                    Application.Current.MainPage.Navigation.PopAsync();

                                                });

                                            }
                                        }
                                    }
                                    else
                                    {
                                        progresss.Dispose();
                                        DependencyService.Get<IAlert>().Alert("ERROR", "Error: Asegurate de que tienes conexión a internet, e intentalo de nuevo " + registrado.ToString());
                                    }
                                }
                                else
                                {
                                    progresss.Dispose();
                                    DependencyService.Get<IAlert>().Alert("ERROR", "Error el correo no es valido");
                                }

                            }
                            if (SelectedRole == "Admin" && Settings.Role == "Admin")
                            {
                                DependencyService.Get<IAlert>().Alert("Ya exite un Administrador", "Lo siento, ya exite un administrador.");

                                Device.BeginInvokeOnMainThread(() => {

                                    Application.Current.MainPage.Navigation.PopAsync();

                                });

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
                }
                catch (Exception e)
                {
                   
                    DependencyService.Get<IAlert>().Alert("error", e.Message + " en " + e.Source + " Stack trace " + e.StackTrace + " Inner Excp. " + e.InnerException);
                    
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

        public RegisterPageViewModel()
        {

            dbRepo = ServiceLocator.Current.GetInstance<DBRepository/*<User>*/>();

            AddRoles();

        }
    }
}
