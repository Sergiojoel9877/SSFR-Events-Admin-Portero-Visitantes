﻿using Plugin.Messaging;
using SSFR_Events.Models;
using SSFR_Events.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SSFR_Events.ViewModels
{
    public class AddGuestViewModel : ViewModelBase
    {
        INavigation _navService;

        public ObservableCollection<string> Gender { get; set; } = new ObservableCollection<string>();

        private bool empty;
        public bool Empty {

            get => empty;

            set => SetProperty(ref empty, value);

        }

        private int guestCount = 0;
        public int GuestCount
        {
            get => guestCount;

            set => SetProperty(ref guestCount, value);
        }

        private string lastNameEntry;
        public string LastNameEntry
        {
            get => lastNameEntry;

            set => SetProperty(ref lastNameEntry, value);
        }

        private string nameEntry;
        public string NameEntry
        {
            get => nameEntry;

            set => SetProperty(ref nameEntry, value);
        }

        private string telephoneNumber;
        public string TelephoneNumber
        {
            get => telephoneNumber;

            set => SetProperty(ref telephoneNumber, value);
        }

        private string emailEntry;
        public string EmailEntry
        {
            get => emailEntry;

            set => SetProperty(ref emailEntry, value);
        }
        
        private Events sendedEvent;
        public Events SendedEvent
        {
            get => sendedEvent;

            set => SetProperty(ref sendedEvent, value);
        }

        private string selectedGender;
        public string SelectedGender
        {
            get => selectedGender;

            set => SetProperty(ref selectedGender, value);
        }

        private bool guestCountEnabled = true;
        public bool GuestCountEnabled {

            get => guestCountEnabled;

            set => SetProperty(ref guestCountEnabled, value);

        }

        private Command register;
        public Command Register
        {
            get => register ?? ( register = new Command( async () => {

                do
                {
                    if(GuestCount != 0)
                    {
                        GuestCountEnabled = false;

                        GuestCount--;

                        if (GuestCount != 0 || NameEntry != null || LastNameEntry != null || TelephoneNumber != null || EmailEntry != null || SelectedGender != null)
                        {
                            Empty = false;

                            if (Empty == false)
                            {

                                var GuestList = await DependencyService.Get<IDBRepoInstance>().getInstance().GetGuests();

                                var query = GuestList.Any(g => g.Email == EmailEntry);

                                if (query)
                                {
                                    DependencyService.Get<IAlert>().Alert("Este invitado ya existe", "Lo siento tal parece que  ya existe un invitado con este correo.");
                                }
                                else
                                {
                                    if (EmailEntry.Contains("@"))
                                    {
                                        try
                                        {

                                            var guest = new Guest()
                                            {
                                                Name = NameEntry,
                                                LastName = LastNameEntry,
                                                Email = EmailEntry,
                                                Gender = SelectedGender,
                                                Telephone = TelephoneNumber,
                                                Event = SendedEvent
                                            };

                                            var r = await DependencyService.Get<IDBRepoInstance>().getInstance().AddGuest(guest);

                                            if (r)
                                            {
                                                var sendEmail = CrossMessaging.Current.EmailMessenger;

                                                if (sendEmail.CanSendEmail)
                                                {

                                                    sendEmail.SendEmail(EmailEntry, "¡Hey hola!", "Señores Sergio Joel Ferreras les escribe, esto es una simple prueba desde mi App (la cual estoy desarrollando), disculpen las molestias que les pueda causar, pasen buenas tardes.");
                                                    
                                                    DependencyService.Get<IAlert>().Alert("Registrado con éxito", "Invitado registrado con éxito");
                                                }
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            DependencyService.Get<IAlert>().Alert("ERROR", "Error: " + e.ToString());
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
                    }
                    else
                    {
                        DependencyService.Get<IAlert>().Alert("Todos los invitados fueron registrados", "Todos los invitados registrados exitosamente");

                        GuestCountEnabled = true;
                    }

                } while (GuestCount > 0);
                
            }));
        }

        void AddGender()
        {
            string M = "Masculino";
            string F = "Femenino";

            Gender.Add(M);
            Gender.Add(F);

        }

        public AddGuestViewModel(INavigation navService, Events evnt)
        {
            _navService = navService;

            AddGender();

            SendedEvent = evnt;
        }
    }
}
