using System;
using System.Collections.Generic;
using System.Text;
using SSFR_Events.Helpers;
using SSFR_Events.Services;
using Xamarin.Forms;

namespace SSFR_Events.ViewModels
{
    public class QRCodeViewModel : ViewModelBase
    {

        private string guestUserName;
        public string GuestUserName
        {
            get => guestUserName;
            set => SetProperty(ref guestUserName, value);
        }

        public QRCodeViewModel()
        {
            GuestUserName = Settings.GuestUserName;
        }
    }
}
