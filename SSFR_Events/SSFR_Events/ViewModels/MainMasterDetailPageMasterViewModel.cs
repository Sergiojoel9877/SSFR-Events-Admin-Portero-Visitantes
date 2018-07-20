using SSFR_Events.Models;
using SSFR_Events.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SSFR_Events.Helpers;

namespace SSFR_Events.ViewModels
{
    public class MainMasterDetailPageMasterViewModel : ViewModelBase
    {

        public ObservableCollection<MainMasterDetailPageMenuItem> MenuItems { get; set; }

        private string role = Settings.Role;
        public string Role {

            get => role;

            set => SetProperty(ref role, value);

        }
        
        public MainMasterDetailPageMasterViewModel()
        {
            MenuItems = new ObservableCollection<MainMasterDetailPageMenuItem>();
            
            FillCollection();
        }

        private void FillCollection()
        {
            if(Settings.Role == "Modo Admin")
            {
               
                MenuItems.Add(new MainMasterDetailPageMenuItem { Id = 6, Title = "Reportes", TargetType = typeof(ReportsPage), ImageSource = "repo.png" });

                MenuItems.Add(new MainMasterDetailPageMenuItem { Id = 1, Title = "Eventos Actuales", TargetType = null, ImageSource = "evn.png" });

                MenuItems.Add(new MainMasterDetailPageMenuItem { Id = 2, Title = "Invitados Por Llegar", TargetType = typeof(GuestToArrivePage), ImageSource = "user.png" });

                MenuItems.Add(new MainMasterDetailPageMenuItem { Id = 3, Title = "Mostrar Invitados", TargetType = null, ImageSource = "ev.png" });

                MenuItems.Add(new MainMasterDetailPageMenuItem { Id = 4, Title = "Buscar Visitantes", TargetType = null, ImageSource = "bv.png" });

                MenuItems.Add(new MainMasterDetailPageMenuItem { Id = 5, Title = "Próximos Eventos", TargetType = null, ImageSource = "x_ev.png" });

            }
            else
            {
                MenuItems.Add(new MainMasterDetailPageMenuItem { Id = 1, Title = "Eventos Actuales", TargetType = typeof(LoginPage), ImageSource = "evn.png" });

                MenuItems.Add(new MainMasterDetailPageMenuItem { Id = 2, Title = "Invitados Por Llegar", TargetType = typeof(GuestToArrivePage), ImageSource = "user.png" });

                MenuItems.Add(new MainMasterDetailPageMenuItem { Id = 3, Title = "Mostrar Invitados", TargetType = typeof(LoginPage), ImageSource = "ev.png" });

                MenuItems.Add(new MainMasterDetailPageMenuItem { Id = 4, Title = "Buscar Visitantes", TargetType = typeof(LoginPage), ImageSource = "bv.png" });
             }
        }
    }
}
