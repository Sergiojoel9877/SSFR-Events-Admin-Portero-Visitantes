using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLiteEntityFramework.cs;
using SSFR_Events.Droid.Services;
using Android.Graphics;
using Android.Support.V4.Content.Res;
//using Android.Gms.Common;

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

            //var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "SSFR_DB.db");

            //DBRepository dBRepository = new DBRepository(path);

           // IsPlayServicesAvailable();

            DBRepoInstance dBRepoInstance = new DBRepoInstance();
            
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(dBRepoInstance.getInstance()));
        }

        //public bool IsPlayServicesAvailable()
        //{
        //    int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
        //    if (resultCode != ConnectionResult.Success)
        //    {
        //        if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
        //        {
        //            // In a real project you can give the user a chance to fix the issue.
        //            Console.WriteLine($"Error: {GoogleApiAvailability.Instance.GetErrorString(resultCode)}");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Error: Play services not supported!");
        //            Finish();
        //        }
        //        return false;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Play Services available.");
        //        return true;
        //    }
        //}
    }
}

