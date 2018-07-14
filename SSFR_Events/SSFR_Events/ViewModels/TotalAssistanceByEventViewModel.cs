using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using SSFR_Events.Services;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SSFR_Events.ViewModels
{
    public class TotalAssistanceByEventViewModel : ViewModelBase
    {
        public ObservableCollection<Event> EventsList { get; set; } = new ObservableCollection<Event>();

        private Command fillListCommand;
        public Command FillListCommand
        {
            get => fillListCommand ?? (fillListCommand = new Command( async () =>
            {
                await Task.Yield();

                await CountAssistance();

            })); 
        }
        
        async Task CountAssistance()
        {
            await Task.Yield();
           
            var guests = await App.ssfrClient.ApiGuestsGetAsync();

            var events = await App.ssfrClient.ApiEventsGetAsync();

            int count = 0;

            foreach (var item in events)
            {
                var guestsQuery = from s in guests where s.EventId == item.Id select s;

                foreach (var u in guestsQuery)
                {
                    count++;
                }

                Event e = new Event { Count = count, Title = item.Name };

                if (!EventsList.Contains(e))
                {
                    EventsList.Add(e);
                }

                count = 0;

                e = null;
            }
        }

        public TotalAssistanceByEventViewModel()
        {
            FillListCommand.Execute(null);
        }

    }

    public class Event
    {
        public int Count { get; set; }

        public string Title { get; set; }
    }
}
