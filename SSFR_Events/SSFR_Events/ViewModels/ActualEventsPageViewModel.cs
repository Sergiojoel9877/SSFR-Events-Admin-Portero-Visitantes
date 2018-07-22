using SSFR_Events.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SSFR_Events.ViewModels
{
    public class ActualEventsPageViewModel : ViewModelBase
    {
        public ObservableCollection<Events> EventsList { get; set; } = new ObservableCollection<Events>();

        private bool thereAreNoEvents = false;
        public bool ThereAreNoEvents
        {
            get => thereAreNoEvents;

            set => SetProperty(ref thereAreNoEvents, value);
        }

        private bool listViewISVISIBLE = true;
        public bool ListViewISVISIBLE
        {
            get => listViewISVISIBLE;

            set => SetProperty(ref listViewISVISIBLE, value);
        }
        
        private Command fillListCommand;
        public Command FillListCommand
        {
            get => fillListCommand ?? (fillListCommand = new Command(async () =>
            {
                await Task.Yield();

                await CountAssistance();
                
            }));
        }

        async Task CountAssistance()
        {
            await Task.Yield();

            string ActualDate = String.Format("{0}/{1}/{2}", DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);

            var events = await App.ssfrClient.ApiEventsGetAsync();
            
            foreach (var item in events)
            {
                //string ItemDate = String.Format("{0}/{1}/{2}", item.Date);
                if (item.Date == ActualDate)
                {
                    EventsList.Add(item);
                }
            }

            if (EventsList.Count == 0)
            {
                ThereAreNoEvents = true;

                ListViewISVISIBLE = false;
            }

        }

        public ActualEventsPageViewModel()
        {
            FillListCommand.Execute(null);
        }
    }
}
