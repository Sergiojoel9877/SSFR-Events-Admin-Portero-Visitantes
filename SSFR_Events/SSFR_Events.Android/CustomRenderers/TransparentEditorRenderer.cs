using System;
using Xamarin.Forms.Platform.Android;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using SSFR_Events.CustomRenderers;
using SSFR_Events.Droid.CustomRenderers;
using SSFR_Events;

[assembly: ExportRenderer(typeof(TransparentEditor), typeof(TransparentEditorRenderer))]
namespace SSFR_Events.Droid.CustomRenderers
{
    public class TransparentEditorRenderer : EntryRenderer
    {
        public TransparentEditorRenderer(Context context) : base(context)
        {
             
        }
        
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(e.NewElement != null)
            {
                var element = e.NewElement as TransparentEditor;
                Control.Hint = element.Placeholder;

                Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);

                // Text alignment.
                if (element.HorizontalTextAlignment == Xamarin.Forms.TextAlignment.Center)
                    Control.Gravity = Android.Views.GravityFlags.CenterHorizontal;
                else if (element.HorizontalTextAlignment == Xamarin.Forms.TextAlignment.Start)
                    Control.Gravity = Android.Views.GravityFlags.Start;
                else if (element.HorizontalTextAlignment == Xamarin.Forms.TextAlignment.End)
                    Control.Gravity = Android.Views.GravityFlags.End;

            }
        }
    }
}