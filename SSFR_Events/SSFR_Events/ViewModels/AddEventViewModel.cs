using SSFR_Events.Models;
using SSFR_Events.Services;
using SSFR_Events.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xamarin.Forms;
using Syncfusion.SfBarcode.XForms;

namespace SSFR_Events.ViewModels
{
    public class AddEventViewModel : ViewModelBase
    {
        INavigation _navService;

        SfBarcode barcode = new SfBarcode();

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
        public Command Register {

            get => register ?? (register = new Command( async () => {

                if (NameEntry != null || Location != null)
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
                            var @event = new SSFR_Events.Services.Events() {
                                Name = NameEntry,
                                Location = Location,
                                Date = DateSelected.ToString(),
                                Time = TimeSelected.ToString(),
                                EventType = EventType
                            };

                            var r = await App.ssfrClient.ApiPostEventPostAsync(@event);
                            
                            barcode.Text = NameEntry;

                            barcode.Symbology = BarcodeSymbolType.QRCode; //ME QUEDE AQUI
                            
                            if (r)
                            {
                                bool a = DependencyService.Get<IAlert>().Alert("¡Añade unos visitantes!", "Ingresa cuantos quieras, ¡No hay limites!");

                                await _navService.PushAsync(new AddGuestPage(@event));
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
                    DependencyService.Get<IAlert>().Alert("Error", "No puedes dejar campos vacios");
                }
                
            }));

        }

        public AddEventViewModel(INavigation navService)
        {
            _navService = navService;
        }
    }
}
