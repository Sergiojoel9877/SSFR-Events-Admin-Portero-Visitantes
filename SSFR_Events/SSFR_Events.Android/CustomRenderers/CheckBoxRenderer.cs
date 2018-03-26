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
using Xamarin.Forms;
using SSFR_Events.Droid;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(SSFR_Events.CustomRenderers.CheckBox), typeof(CheckBoxRenderer))]
namespace SSFR_Events.Droid
{
    public class CheckBoxRenderer : ViewRenderer<SSFR_Events.CustomRenderers.CheckBox, Android.Widget.CheckBox>
    {
        private Android.Widget.CheckBox checkBox;

        public CheckBoxRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<SSFR_Events.CustomRenderers.CheckBox> e)
        {
            base.OnElementChanged(e);
            var model = e.NewElement;
            checkBox = new Android.Widget.CheckBox(Context);
            checkBox.Tag = this;
            CheckboxPropertyChanged(model, null);
            checkBox.SetOnClickListener(new ClickListener(model));
            SetNativeControl(checkBox);
        }
        private void CheckboxPropertyChanged(SSFR_Events.CustomRenderers.CheckBox model, String propertyName)
        {
            if (propertyName == null || SSFR_Events.CustomRenderers.CheckBox.IsCheckedProperty.PropertyName == propertyName)
            {
                checkBox.Checked = model.IsChecked;
            }

            if (propertyName == null || SSFR_Events.CustomRenderers.CheckBox.ColorProperty.PropertyName == propertyName)
            {
                int[][] states = {
                    new int[] { Android.Resource.Attribute.StateEnabled}, // enabled
                    new int[] {Android.Resource.Attribute.StateEnabled}, // disabled
                    new int[] {Android.Resource.Attribute.StateChecked}, // unchecked
                    new int[] { Android.Resource.Attribute.StatePressed}  // pressed
                };
                var checkBoxColor = (int)model.Color.ToAndroid();
                int[] colors = {
                    checkBoxColor,
                    checkBoxColor,
                    checkBoxColor,
                    checkBoxColor
                };
                var myList = new Android.Content.Res.ColorStateList(states, colors);
                checkBox.ButtonTintList = myList;

            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (checkBox != null)
            {
                base.OnElementPropertyChanged(sender, e);

                CheckboxPropertyChanged((SSFR_Events.CustomRenderers.CheckBox)sender, e.PropertyName);
            }
        }

        public class ClickListener : Java.Lang.Object, IOnClickListener
        {
            private SSFR_Events.CustomRenderers.CheckBox _myCheckbox;
            public ClickListener(SSFR_Events.CustomRenderers.CheckBox myCheckbox)
            {
                this._myCheckbox = myCheckbox;
            }
            public void OnClick(global::Android.Views.View v)
            {
                _myCheckbox.IsChecked = !_myCheckbox.IsChecked;
            }
        }
    }
}