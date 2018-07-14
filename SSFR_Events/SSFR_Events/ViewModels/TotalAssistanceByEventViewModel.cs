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
        public ObservableCollection<Events> EventsList { get; set; } = new ObservableCollection<Events>();

        public ObservableCollection<Event> Events { get; set; } = new ObservableCollection<Event>();

        private Command fillListCommand;
        public Command FillListCommand
        {
            get => fillListCommand ?? (fillListCommand = new Command( async () =>
            {
                await Task.Yield();

                await FillList();

            })); 
        }
        
        async Task FillList()
        {
            await Task.Yield();

            var events = await App.ssfrClient.ApiEventsGetAsync();

            events.ForEach(s => EventsList.Add(s));

        }

        async Task CountAssistance()
        {
            await Task.Yield();
           
            var guests = await App.ssfrClient.ApiGuestsGetAsync();

            var events = await App.ssfrClient.ApiEventsGetAsync();

            //var guestsQuery = from s in guests where s.EventId == 
                              
            //foreach (var u in guestsQuery)
            //{
            //    //Events.Add();
            //}
        }

        public TotalAssistanceByEventViewModel()
        {
            FillListCommand.Execute(null);
        }

    }

    class Event
    {
        public int Count { get; set; }

        public string Title { get; set; }

    }
}
