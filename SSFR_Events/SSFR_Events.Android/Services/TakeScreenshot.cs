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
using SSFR_Events.Droid.Services;
using Xamarin.Forms;
using Android.Graphics;
using System.IO;

[assembly: Dependency(typeof(TakeScreenshot))]
namespace SSFR_Events.Droid.Services
{
    public class TakeScreenshot : ITakeScreenshot
    {

        private Activity currentActivity;

        public void SetActivity(Activity activity)
        {
            currentActivity = activity;
        }

        byte[] ITakeScreenshot.Capture()
        {
            var rootView = currentActivity.Window.DecorView.RootView;

            using ( var screenShot = Bitmap.CreateBitmap(rootView.Width, rootView.Height - 150, Bitmap.Config.Argb8888))
            {
                Canvas canvas = new Canvas(screenShot);

                rootView.Draw(canvas);

                using (var stream = new MemoryStream())
                {
                    screenShot.Compress(Bitmap.CompressFormat.Png, 100, stream);
                    stream.ToArray();
                }
            }

            return null;

        }
    }
}