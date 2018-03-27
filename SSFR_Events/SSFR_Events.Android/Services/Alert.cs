
using Android.App;
using Android.Content;
using SSFR_Events.Droid.Services;
using SSFR_Events.Services;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(Alert))]
namespace SSFR_Events.Droid.Services
{
    class Alert : IAlert
    {
#pragma warning disable CS0618
        Activity activity = (MainActivity)Forms.Context;
#pragma warning restore CS068

        bool Yes = false;

        AlertDialog.Builder Ab;

        bool IAlert.Alert(string title, string msg)
        {
            ShowAlert(title, msg);

            return Yes;
        }

        public void ShowAlert(string title, string msg)
        {
            AB(title, msg, "Ok");
        }

        public void AB(string title, string msg, string yes)
        {

            Ab = new AlertDialog.Builder(activity);

            Ab.SetTitle(title).SetMessage(msg).SetPositiveButton("Ok", OnClick);

            var create = Ab.Create();

            create.Show();

        }

        public void OnClick(object dialog, DialogClickEventArgs e)
        {
            Yes = true;
        }
    }
}