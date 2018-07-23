using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SSFR_Events.ViewModels;
using SSFR_Events.Data;

namespace SSFR_Events.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActualEventsPage : ContentPage
	{
        ActualEventsPageViewModel vm;

		public ActualEventsPage ()
		{
			InitializeComponent ();

            vm = ((ViewModelLocator)Application.Current.Resources["Locator"]).ActualEventsPageViewModel;

            BindingContext = vm;

            AssistanceListView.ItemSelected += AssistanceListView_ItemSelected;

        }

        private void AssistanceListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var list = (ListView)sender;
             
            list.SelectedItem = null;
        }
    }
}