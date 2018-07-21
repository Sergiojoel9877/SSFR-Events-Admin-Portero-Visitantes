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

        private string eventName;
        public string EventName
        {
            get => eventName;
            set => SetProperty(ref eventName, value);
        }

        public QRCodeViewModel()
        {
            EventName = Settings.EventName;
        }
    }
}
