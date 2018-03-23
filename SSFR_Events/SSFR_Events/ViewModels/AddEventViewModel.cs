using SSFR_Events.Models;
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

        public AddEventViewModel(INavigation navService)
        {
            _navService = navService;
        }

    }
}
