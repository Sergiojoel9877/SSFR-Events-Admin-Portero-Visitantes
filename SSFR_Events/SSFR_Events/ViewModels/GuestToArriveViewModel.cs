using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using SSFR_Events.Services;
using Acr.UserDialogs;
using Plugin.Connectivity;

namespace SSFR_Events.ViewModels
{
    public class GuestToArriveViewModel : ViewModelBase
    {
        INavigation _navService;

        public ObservableCollection<Guest> GuestList { get; set; } = new ObservableCollection<Guest>();

        private string name;
        public string Name
        {
            get => name;

            set => SetProperty(ref name, value);

        }
        
        private Command search;
        public Command Search
        {

            get => search ?? (search = new Command(async () =>
            {
                GuestList.Clear();

                if (!CrossConnectivity.Current.IsConnected)
                {
                    DependencyService.Get<IAlert>().Alert("Error", "Al parecer no tienes acceso a intenet.");
                    return;
                }

                IProgressDialog progresss = UserDialogs.Instance.Loading("Por favor espera", null, null, true, MaskType.Black);

                var guestList = await App.ssfrClient.ApiGuestsGetAsync();

                var eventList = await App.ssfrClient.ApiEventsGetAsync();

                var exist = eventList.Any(e => e.Name == Name);

                if (!exist)
                {
                    progresss.Dispose();
                    DependencyService.Get<IToast>().LongAlert("Este evento no existe, intenta otra vez.");
                    return;
                }

                foreach (Events i in eventList)
                {
                    if(i.Name == Name)
                    {
                        var evnt = guestList.Where(e => e.EventId == i.Id);

                        foreach (var e in evnt)
                        {
                            var existe = GuestList.Any(ex => ex.Name == e.Name);

                            if (!existe)
                            {
                                GuestList.Add(e);
                            }

                            DependencyService.Get<IToast>().LongAlert("Estos son todos los invitados..");
                           
                        }

                        progresss.Dispose();
                    }
                }
                
            }));
        }
        
        public GuestToArriveViewModel(INavigation navService)
        {
            _navService = navService;
        }

    }
}
