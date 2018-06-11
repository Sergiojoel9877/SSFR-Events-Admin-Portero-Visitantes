using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Com.OneSignal;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SSFR_Events.Droid
{
    [Activity(Label = "SSFR_Events", Icon = "@drawable/ic_launcher", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;

                base.OnCreate(bundle);

                //var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "SSFR_DB.db");

                //DBRepository dBRepository = new DBRepository(path);

                OneSignal.Current.StartInit("23fbe6ba-7814-4714-aa75-00a3480f5b68").EndInit();

                UserDialogs.Init(this);

                global::Xamarin.Forms.Forms.Init(this, bundle);

                LoadApplication(new App());
            }
            catch (Exception e)
            {
                var properties = new Dictionary<string, string>
                {
                    {"Message", e.Message },
                    {"Source", e.Source },
                    {"StackTrace", e.StackTrace }
                };
                Crashes.TrackError(e);

            }
           
        }

//        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
//        {
//#pragma warning disable
//            PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
//#pragma warning restore
//        }

    }
}

