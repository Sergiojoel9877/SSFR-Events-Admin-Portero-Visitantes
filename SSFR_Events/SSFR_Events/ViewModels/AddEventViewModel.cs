using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SSFR_Events.ViewModels
{
    public class AddEventViewModel : ViewModelBase
    {
        INavigation _navService;

        public AddEventViewModel(INavigation navService)
        {
            _navService = navService;
        }
    }
}
