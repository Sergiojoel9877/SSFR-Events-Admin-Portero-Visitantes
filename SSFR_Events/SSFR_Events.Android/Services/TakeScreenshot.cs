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
using Plugin.CurrentActivity;
using System.IO;
using SSFR_Events.Helpers;

[assembly: Dependency(typeof(TakeScreenshot))]
namespace SSFR_Events.Droid.Services
{
    public class TakeScreenshot : ITakeScreenshot
    { 

        public bool Capture()
        {
            var rootView =  CrossCurrentActivity.Current.Activity.Window.DecorView.RootView;

            var height = rootView.Height;

            var width = rootView.Width;

            using ( var screenShot = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888))
            {
                Canvas canvas = new Canvas(screenShot);

                rootView.Draw(canvas);

                var storage = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures).Path;
      
                var file = System.IO.Path.Combine(storage, "TuCodigoQR.png");

                Settings.Path = file; 

                var stream = new FileStream(file, FileMode.Create);

                screenShot.Compress(Bitmap.CompressFormat.Png, 100, stream);

                stream.Close();

                return true;
            }
        }
    }
}