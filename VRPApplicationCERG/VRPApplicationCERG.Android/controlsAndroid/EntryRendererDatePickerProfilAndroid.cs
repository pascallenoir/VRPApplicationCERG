using System;
using Android.Content;
using VRPApplicationCERG.Controls;
using VRPApplicationCERG.Droid.controlsAndroid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryRendererDatePickerProfil), typeof(EntryRendererDatePickerProfilAndroid))]
namespace VRPApplicationCERG.Droid.controlsAndroid
{
    public class EntryRendererDatePickerProfilAndroid : DatePickerRenderer
    {

        public EntryRendererDatePickerProfilAndroid(Context context) : base(context)
        {

        }

        public static void Init() { }
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {

                Control.SetBackgroundResource(Resource.Layout.Rounded_shape3);
                var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                layoutParams.SetMargins(0, 0, 0, 0);
                LayoutParameters = layoutParams;
                Control.LayoutParameters = layoutParams;
                Control.SetPadding(0, 0, 0, 0);
                SetPadding(0, 0, 0, 0);
            }
        }
    }
}