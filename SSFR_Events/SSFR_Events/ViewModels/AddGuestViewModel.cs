using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SSFR_Events.ViewModels
{
    public class AddGuestViewModel : ViewModelBase
    {
        INavigation _navService;

        public ObservableCollection<string> Gender { get; set; } = new ObservableCollection<string>();

        private int guestCount = 0;
        public int GuestCount
        {
            get => guestCount;

            set => SetProperty(ref guestCount, value);
        }

        private string lastNameEntry;
        public string LastNameEntry
        {
            get => lastNameEntry;

            set => SetProperty(ref lastNameEntry, value);
        }

        private string sendedString;
        public string SendedString
        {
            get => sendedString;

            set => SetProperty(ref sendedString, value);
        }

        void AddGender()
        {
            string M = "Masculino";
            string F = "Femenino";

            Gender.Add(M);
            Gender.Add(F);

        }

        public AddGuestViewModel(INavigation navService, string enTyp)
        {
            _navService = navService;

            AddGender();

            SendedString = enTyp;
        }
    }
}
