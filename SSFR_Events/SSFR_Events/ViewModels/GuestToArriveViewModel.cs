using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SSFR_Events.ViewModels
{
    public class GuestToArriveViewModel : ViewModelBase
    {
        INavigation _navService;

        public GuestToArriveViewModel(INavigation navService)
        {
            _navService = navService;
        }

    }
}
