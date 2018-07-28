using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Plugin.CurrentActivity;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace SSFR_Events.Droid
{
#if DEBUG
    [Application(Debuggable = true)]
#else
[Application(Debuggable = false)]
#endif
    public class MainApplication : Application
    {
        public static MainApplication instance;
        public static Activity activity;
        public static MainApplication GetIntance()
        {
            return instance;
        }

        public MainApplication(IntPtr handle, JniHandleOwnership transer)
            : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            instance = this;

            AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironment_UnhandledExceptionRaiser;

            CrossCurrentActivity.Current.Init(this);

        }

        private void AndroidEnvironment_UnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs e)
        {
            var intent = new Intent(activity, typeof(MainActivity));
            intent.PutExtra("crash", true);
            intent.AddFlags(ActivityFlags.ClearTop | ActivityFlags.ClearTask | ActivityFlags.NewTask);

            var pendingIntent = PendingIntent.GetActivity(MainApplication.instance, 0, intent, PendingIntentFlags.OneShot);
            
            var mgr = (AlarmManager)MainApplication.instance.GetSystemService(Context.AlarmService);
            mgr.Set(AlarmType.Rtc, DateTime.Now.Millisecond + 20, pendingIntent);

            activity.Finish();
            JavaSystem.Exit(2);
            
        }

        protected override void Dispose(bool disposing)
        {
            AndroidEnvironment.UnhandledExceptionRaiser -= AndroidEnvironment_UnhandledExceptionRaiser;
            base.Dispose(disposing);
        }
    }
}