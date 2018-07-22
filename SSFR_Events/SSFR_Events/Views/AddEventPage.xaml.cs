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

        string date { get; set; }

        public AddEventPage()
		{
            InitializeComponent();

            ViewModel = ((ViewModelLocator)Application.Current.Resources["Locator"]).AddEventViewModel;

            BindingContext = ViewModel;

            DatePicker.DateSelected += OnDateSelected;

            date = String.Format("{0}/{1}/{2}", DatePicker.Date.Day, DatePicker.Date.Month, DatePicker.Date.Year);

            ViewModel.DateSelected = date;

            PushToGuestPage();

        }

        public void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            var obj = (DatePicker)sender;

            date = String.Format("{0}/{1}/{2}", obj.Date.Day, obj.Date.Month, obj.Date.Year);

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