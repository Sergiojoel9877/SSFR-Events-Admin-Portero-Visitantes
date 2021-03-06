﻿using Acr.UserDialogs;
using Plugin.Connectivity;
using Plugin.Messaging;
using SSFR_Events.Models;
using SSFR_Events.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Syncfusion.SfBarcode.XForms;
using PCLStorage;
using System.Threading.Tasks;
using Xamarin.Essentials;
using SSFR_Events.Helpers;
using Rg.Plugins.Popup.Services;
using SSFR_Events.Views;

namespace SSFR_Events.ViewModels
{
    public class AddGuestViewModel : ViewModelBase
    {

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
        
        private SSFR_Events.Services.Events sendedEvent;
        public SSFR_Events.Services.Events SendedEvent
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

        //private Command getEvents;
        //public Command GetEvents
        //{
        //    get => getEvents ?? (getEvents = new Command( async ()=>
        //    {

        //        SendedEvent = await App.ssfrClient.ApiEventsGetAsync().Result.FirstOrDefault(e => e.Name == evnt.Name);

        //    }));
        //}

        private Command register;
        public Command Register
        {
            get => register ?? ( register = new Command( async () =>
            {

                if (!CrossConnectivity.Current.IsConnected)
                {
                    DependencyService.Get<IAlert>().Alert("Error", "Al parecer no tienes acceso a intenet.");
                    return;
                }

                IProgressDialog progresss = UserDialogs.Instance.Loading("Por favor espera", null, null, true, MaskType.Black);

                var res = GuestCount--;

                do
                {

                    GuestCountEnabled = false;
                    
                    if (NameEntry != null && LastNameEntry != null && TelephoneNumber != null && EmailEntry != null && SelectedGender != null)
                    {
                        Empty = false;

                        if (Empty == false)
                        {

                            var GuestList = await App.ssfrClient.ApiGuestsGetAsync();

                            var EventsList = await App.ssfrClient.ApiEventsGetAsync();

                            var queryEvents = EventsList.FirstOrDefault(e => e.Name == SendedEvent.Name);

                            var query = GuestList.Any(g => g.Email == EmailEntry && g.EventId == queryEvents.Id);

                            if (query)
                            {
                                DependencyService.Get<IAlert>().Alert("Este invitado ya existe", "Lo siento tal parece que ya existe un invitado con este correo.");

                                res = guestCount;

                                progresss.Dispose();
                            }
                            else
                            {
                                if (EmailEntry.Contains("@"))
                                {
                                    try
                                    {
                                        Guest guest;

                                        if (SelectedGender == "Masculino")
                                        {
                                            guest = new SSFR_Events.Services.Guest()
                                            {
                                                Name = NameEntry,
                                                LastName = LastNameEntry,
                                                Email = EmailEntry,
                                                Gender = "M",
                                                Telephone = TelephoneNumber,
                                                EventId = queryEvents.Id
                                            };

                                        }
                                        else
                                        {
                                            guest = new SSFR_Events.Services.Guest()
                                            {
                                                Name = NameEntry,
                                                LastName = LastNameEntry,
                                                Email = EmailEntry,
                                                Gender = "F",
                                                Telephone = TelephoneNumber,
                                                EventId = queryEvents.Id
                                            };
                                        }

                                        var r = await App.ssfrClient.ApiGuestPostAsync(guest);

                                        Settings.GuestUserName = guest.Name;

                                        if (r)
                                        {

                                            progresss.Dispose();

                                            await PopupNavigation.Instance.PushAsync(new QRCodePage());

                                            var screenshot = DependencyService.Get<ITakeScreenshot>().Capture();

                                            if (screenshot)
                                            {
                                                await PopupNavigation.Instance.PopAsync();

                                                var sendEmail = CrossMessaging.Current.EmailMessenger;

                                                if (sendEmail.CanSendEmail)
                                                {

                                                    var mail = new EmailMessageBuilder()
                                                    .To(EmailEntry)
                                                    .Subject("¡Hey hola, te he invitado a mi nuevo evento!")
                                                    .WithAttachment(Settings.Path, "image/png")
                                                    .Body("Mi evento es de nombre: " + SendedEvent.Name + " empieza el " + SendedEvent.Date + " a las " + SendedEvent.Time + " a celebrarse en " + SendedEvent.Location)
                                                    .Build();

                                                    sendEmail.SendEmail(mail);

                                                    DependencyService.Get<IAlert>().Alert("Registrado con éxito", "Invitado registrado con éxito");

                                                    NameEntry = null;
                                                    LastNameEntry = null;
                                                    EmailEntry = null;
                                                    SelectedGender = null;
                                                    TelephoneNumber = null;

                                                    GuestCountEnabled = true;

                                                }
                                            }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        progresss.Dispose();

                                        DependencyService.Get<IAlert>().Alert("ERROR", "Error: " + e.ToString());
                                    }
                                }
                                else
                                {
                                    progresss.Dispose();

                                    DependencyService.Get<IAlert>().Alert("ERROR", "Error el correo no es valido");
                                }
                                progresss.Dispose();

                            }
                            progresss.Dispose();

                        }
                        else
                        {
                            progresss.Dispose();

                            DependencyService.Get<IAlert>().Alert("Error", "No puedes dejar campos vacios, y/o las contraseña no son iguales, intenta una vez mas.");
                        }
                        progresss.Dispose();

                    }
                    else
                    {
                        progresss.Dispose();

                        DependencyService.Get<IAlert>().Alert("Error", "No puedes dejar campos vacios, y/o las contraseña no son iguales, intenta una vez mas.");
                    }

                    if (res == 0)
                    {
                        progresss.Dispose();

                        DependencyService.Get<IAlert>().Alert("Todos los invitados fueron registrados", "Yo todos los invitados han sido registrados exitosamente.");

                    }


                } while (res <= GuestCount);
                
            }));
        }

        void AddGender()
        {
            string M = "Masculino";
            string F = "Femenino";

            Gender.Add(M);
            Gender.Add(F);

        }

        public AddGuestViewModel(SSFR_Events.Services.Events evnt)
        {
           
            AddGender();

            SendedEvent = evnt;
           
        }
    }
}
