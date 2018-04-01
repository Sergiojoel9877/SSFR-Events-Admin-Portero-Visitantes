using SSFR_Events.Models;
using SSFR_Events.Services;
using SSFR_Events.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xamarin.Forms;

namespace SSFR_Events.ViewModels
{
    public class AddEventViewModel : ViewModelBase
    {
        INavigation _navService;

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

        private TimeSpan dateSelected;
        public TimeSpan DateSelected
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
        
        private Command register;
        public Command Register {

            get => register ?? (register = new Command( async () => {

                if (NameEntry != null || DateSelected != null || TimeSelected != null || Location != null)
                {
                    Empty = false;

                if (Empty == false)
                {
                    var events = await DependencyService.Get<IDBRepoInstance>().getInstance().GetEvents();

                    var query = events.Any(e => e.Name == NameEntry);

                        if (query)
                        {
                            DependencyService.Get<IAlert>().Alert("Este invitado ya existe", "Lo siento tal parece que  ya existe un invitado con este correo.");
                        }
                        else
                        {
                            var @event = new Events() {
                                Name = NameEntry,
                                Location = Location,
                                Date = DateSelected.ToString(),
                                Time = TimeSelected.ToString(),
                                EventType = EventType
                            };

                            var r = await DependencyService.Get<IDBRepoInstance>().getInstance().AddEvent(@event);

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
                    DependencyService.Get<IAlert>().Alert("Error", "No puedes dejar campos vacios, y/o las contraseña no son iguales, intenta una vez mas.");
                }
                
            }));

        }

        public AddEventViewModel(INavigation navService)
        {
            _navService = navService;
        }
    }
}
