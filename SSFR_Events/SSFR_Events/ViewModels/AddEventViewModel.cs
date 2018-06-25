using SSFR_Events.Models;
using SSFR_Events.Services;
using SSFR_Events.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;
using Xamarin.Forms;
using Syncfusion.SfBarcode.XForms;
using Acr.UserDialogs;
using Plugin.Connectivity;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Newtonsoft.Json;

namespace SSFR_Events.ViewModels
{
    public class AddEventViewModel : ViewModelBase
    {
        
        private bool empty;
        public bool Empty
        {
            get => empty;

            set => SetProperty(ref empty, value);
        }

        private string nameEntry;
        public string NameEntry
        {
            get => nameEntry;

            set => SetProperty(ref nameEntry, value);
        }

        private string eventType;
        public string EventType
        {
            get => eventType;

            set => SetProperty(ref eventType, value);
        } 

        private DateTime dateSelected;
        public DateTime DateSelected
        {
            get => dateSelected;

            set => SetProperty(ref dateSelected, value);
        }

        private TimeSpan timeSelected;
        public TimeSpan TimeSelected
        {
            get => timeSelected;

            set => SetProperty(ref timeSelected, value);
        }

        private string location;
        public string Location
        {
            get => location;

            set => SetProperty(ref location, value);
        }

        private void ChangeDate(DateTime newDate)
        {
            DateSelected = newDate; 
        }

        private Command register;
        public Command Register => register ?? (register = new Command(async () =>
            {

                if (!CrossConnectivity.Current.IsConnected)
                {
                    DependencyService.Get<IAlert>().Alert("Error", "Al parecer no tienes acceso a intenet.");
                    return;
                }

                IProgressDialog progresss = UserDialogs.Instance.Loading("Por favor espera", null, null, true, MaskType.Black);

                if (NameEntry != null && Location != null)
                {
                    Empty = false;

                    if (Empty == false)
                    {

                        var events = await App.ssfrClient.ApiEventsGetAsync();

                        var query = events.Any(e => e.Name == NameEntry);

                        if (query)
                        {
                            DependencyService.Get<IAlert>().Alert("Este Evento ya existe", "Lo siento tal parece que ya existe un evento con este correo.");
                        }
                        else
                        {
                            var @event = new SSFR_Events.Services.Events()
                            {
                                Name = NameEntry,
                                Location = Location,
                                Date = DateSelected.ToString(),
                                Time = TimeSelected.ToString(),
                                EventType = EventType
                            };

                            var r = await App.ssfrClient.ApiPostEventPostAsync(@event);

                            /**TODO: AutoGenerar el Codigo QR, para cada evento y guardarlo en una carpeta de nombre cualsea dentro de la galeria..**/

                            progresss.Dispose();

                            if (r)
                            {
                                bool a = DependencyService.Get<IAlert>().Alert("¡Añade unos visitantes!", "Ingresa cuantos quieras, ¡No hay limites!");

                                MessagingCenter.Send(this, "PushToGuestPage", new AddGuestPage(@event));

                                //App.Current.MainPage.Navigation.PushAsync(new AddGuestPage(@event/*, barcode*/));
                            }
                        }

                        progresss.Dispose();
                    }
                    else
                    {
                        progresss.Dispose();
                        DependencyService.Get<IAlert>().Alert("Error", "No puedes dejar campos vacios, y/o las contraseña no son iguales, intenta una vez mas.");
                    }
                }
                else
                {
                    progresss.Dispose();
                    DependencyService.Get<IAlert>().Alert("Error", "No puedes dejar campos vacios");
                }
                progresss.Dispose();

            }));

        //Covert Image to Array

        private void ImageToByte(Image image)
        {

            using (var ms = new MemoryStream())
            {
                
            }

        }
        public AddEventViewModel()
        {
            MessagingCenter.Subscribe<MainPanelPageViewModel, string>(this, "EventType", (s, e) =>
            {

                EventType = e;

            });

            MessagingCenter.Unsubscribe<MainPanelPageViewModel, string>(this, "EventType");
        }
    }
}
