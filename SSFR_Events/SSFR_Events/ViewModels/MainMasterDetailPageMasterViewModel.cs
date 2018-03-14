using SSFR_Events.Models;
using SSFR_Events.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SSFR_Events.ViewModels
{
    public class MainMasterDetailPageMasterViewModel : ViewModelBase
    {

        public ObservableCollection<MainMasterDetailPageMenuItem> MenuItems { get; set; }

        public MainMasterDetailPageMasterViewModel()
        {
            MenuItems = new ObservableCollection<MainMasterDetailPageMenuItem>();

            FillCollection();
        }

        private void FillCollection()
        {

            MenuItems.Add(new MainMasterDetailPageMenuItem { Id = 0, Title = "Reportes", TargetType = typeof(LoginPage), ImageSource = "icon.png" });
        }

    }
}
