using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using SSFR_Events.Services;

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
                var guestList = await App.ssfrClient.ApiGuestsGetAsync();

                var eventList = await App.ssfrClient.ApiEventsGetAsync();

                foreach (Events i in eventList)
                {
                    if(i.Name == Name)
                    {
                        var evnt = guestList.Where(e => e.EventId == i.Id);

                        foreach (var e in evnt)
                        {
                            GuestList.Add(e);
                        }
                        
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
