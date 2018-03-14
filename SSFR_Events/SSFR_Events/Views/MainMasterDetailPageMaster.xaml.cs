using SSFR_Events.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SSFR_Events.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        private MainMasterDetailPageMasterViewModel ViewModel;

        public MainMasterDetailPageMaster()
        {
            InitializeComponent();

            ViewModel = new MainMasterDetailPageMasterViewModel();

            BindingContext = ViewModel;

            ListView = MenuItemsListView;
        }
    }
}