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

        public AddEventPage(string eventType)
		{
            InitializeComponent();

            ViewModel = new AddEventViewModel(Navigation);

            ViewModel.EventType = eventType;

            BindingContext = ViewModel;
        }
    }
}