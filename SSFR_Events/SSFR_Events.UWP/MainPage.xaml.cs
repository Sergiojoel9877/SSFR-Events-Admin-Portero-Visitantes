using SQLiteEntityFramework.cs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SSFR_Events.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            var path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            string fullPath = Path.Combine(path, "SSFR_DB.db");

            DBRepository dBRepository = new DBRepository(path);

            LoadApplication(new SSFR_Events.App(dBRepository));
        }
    }
}
