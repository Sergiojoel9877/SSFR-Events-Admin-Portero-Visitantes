using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLiteEntityFramework.cs;

namespace SSFR_Events.Droid
{
    [Activity(Label = "SSFR_Events", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "SSFR_DB.db");

            DBRepository dBRepository = new DBRepository(path);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(dBRepository));
        }
    }
}

