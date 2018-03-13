using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SSFR_Events.Services;

[assembly: Xamarin.Forms.Dependency(typeof(GateKeeper_WMS.Droid.ToastAlert))]
namespace GateKeeper_WMS.Droid
{
    public class ToastAlert : IToast
    {
        public void LongAlert(string msg)
        {
            Toast.MakeText(Application.Context, msg, ToastLength.Long).Show();
        }

        public void ShortAlert(string msg)
        {
            Toast.MakeText(Application.Context, msg, ToastLength.Short).Show();

        }
    }
}