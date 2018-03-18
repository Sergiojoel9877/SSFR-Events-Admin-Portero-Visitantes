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
using SSFR_Events.Droid.Services;
using SSFR_Events.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(CloseBackPress))]
namespace SSFR_Events.Droid.Services
{
    public class CloseBackPress : Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ICloseBackPress
    {
#pragma warning disable CS0618
        Activity activity = (MainActivity)Forms.Context;
#pragma warning restore CS068

        public void Close()
        {
            OnBackPressed();
        }

        public override void OnBackPressed()
        {
            ShowAlert("Estás a punto de salir", "¿Estás seguro de que deseas salir?");
        }

        AlertDialog.Builder Ab;

        public void ShowAlert(string title, string msg)
        {
            AB(title, msg, "Ok");
        }

        public void AB(string title, string msg, string yes)
        {

            Ab = new AlertDialog.Builder(activity);

            Ab.SetTitle(title).SetMessage(msg).SetPositiveButton(yes, OnClick);

            var create = Ab.Create();

            create.Show();

        }

        public void OnClick(object dialog, DialogClickEventArgs e)
        {
            activity.FinishAffinity();  
        }
    }
}