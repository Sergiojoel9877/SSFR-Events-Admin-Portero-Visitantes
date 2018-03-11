using Android.Widget;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SSFR_Events.CustomRenderers
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class CheckBox : View
    {

        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create<CheckBox, bool>(p => p.IsChecked, true, propertyChanged: (s, o, n) => { (s as CheckBox).OnChecked(new EventArgs()); });

        public static readonly BindableProperty ColorProperty = BindableProperty.Create<CheckBox, Color>(p => p.Color, Color.Default);

        public bool IsChecked
        {
            get
            {
                return (bool)GetValue(IsCheckedProperty);
            }
            set
            {
                SetValue(IsCheckedProperty, value);
            }
        }

        public Color Color
        {
            get
            {
                return (Color)GetValue(ColorProperty);
            }
            set
            {
                SetValue(ColorProperty, value);
            }
        }

        public event EventHandler Checked;

        protected virtual void OnChecked(EventArgs e)
        {
            if (Checked != null)
                Checked(this, e);
        }
    }
#pragma warning disable CS0618 // Type or member is obsolete
}
