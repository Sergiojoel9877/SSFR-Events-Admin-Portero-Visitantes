using SSFR_Events.Models;
using SSFR_Events.Services;
using SSFR_Events.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SSFR_Events.ViewModels
{
    public class AddEventViewModel : ViewModelBase
    {
        INavigation _navService;

        private string eventType;
        public string EventType
        {
            get => eventType;

            set => SetProperty(ref eventType, value);
        }

        private Command register;
        public Command Register {

            get => register ?? (register = new Command( () => {

                bool a = DependencyService.Get<IAlert>().Alert("¿Deseas Añadir visitantes?", "Ingresa cuantos quieras, !No hay limites!");
          
                _navService.PushAsync(new AddGuestPage(EventType));
                
            }));

        }

        public AddEventViewModel(INavigation navService)
        {
            _navService = navService;
        }
    }
}
