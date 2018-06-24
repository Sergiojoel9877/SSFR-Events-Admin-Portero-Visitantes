using SSFR_Events.Data;
using SSFR_Events.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SSFR_Events.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEventPage : ContentPage
	{
        AddEventViewModel ViewModel;

        DateTime date { get; set; }

        public AddEventPage(string eventType)
		{
            InitializeComponent();

            ViewModel = ((ViewModelLocator)Application.Current.Resources["Locator"]).AddEventViewModel;

            ViewModel.EventType = eventType;

            BindingContext = ViewModel;

            DatePicker.DateSelected += OnDateSelected;

            PushToGuestPage();

        }

        public void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            date = e.NewDate.Date;

            ViewModel.DateSelected = date;
        }

        void PushToGuestPage()
        {
            MessagingCenter.Subscribe<AddEventViewModel, AddGuestPage>(this, "PushToGuestPage", (s, e) =>
            {
                Navigation.PushAsync(e);
            });
        }
    }
}