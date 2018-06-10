using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using SSFR_Events.Droid.Services;
using Android.Graphics;
using Android.Support.V4.Content.Res;
using Android.Gms.Common;
using Firebase.Iid;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Android.Content;
using Android.Support.V7.App;
using Android.Media;
using System.Diagnostics;
using Com.OneSignal;
using Acr.UserDialogs;
using Microsoft.AppCenter.Crashes;
using System.Collections.Generic;
using ZXing.Net.Mobile.Forms.Android;

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

                ZXing.Net.Mobile.Forms.Android.Platform.Init();

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

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
#pragma warning disable
            PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
#pragma warning restore
        }

    }
}

