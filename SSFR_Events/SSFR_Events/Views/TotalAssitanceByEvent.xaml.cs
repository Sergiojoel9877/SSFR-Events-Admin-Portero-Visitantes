using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSFR_Events.Data;
using SSFR_Events.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SSFR_Events.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TotalAssitanceByEvent : ContentPage
	{

        TotalAssistanceByEventViewModel vm;

		public TotalAssitanceByEvent ()
		{
			InitializeComponent ();

            vm = ((ViewModelLocator)Application.Current.Resources["Locator"]).TotalAssistanceByEventViewModel;

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