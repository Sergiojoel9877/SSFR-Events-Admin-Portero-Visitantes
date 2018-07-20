using SSFR_Events.Models;
using SSFR_Events.Services;
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
    public partial class MainMasterDetailPage : MasterDetailPage
    {
        public MainMasterDetailPage()
        {
            InitializeComponent();

            var detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MainPanelPage)));

            detail.BarTextColor = Color.FromHex("#FFA500");

            Detail = detail;

            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainMasterDetailPageMenuItem;

            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);

            page.Title = item.Title;

            switch (page.Title)
            {
                case "Mostrar Eventos":
                    DependencyService.Get<IToast>().LongAlert("Esta vista aún no está implementada");
                    break;
                case "Eventos Actuales":
                    DependencyService.Get<IToast>().LongAlert("Esta vista aún no está implementada");
                    break;
                case "Buscar Visitantes":
                    DependencyService.Get<IToast>().LongAlert("Esta vista aún no está implementada");
                    break;
                case "Próximos Eventos":
                    DependencyService.Get<IToast>().LongAlert("Esta vista aún no está implementada");
                    break;
                default:
                    break;
            }

            Detail.Navigation.PushAsync(page);

            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}