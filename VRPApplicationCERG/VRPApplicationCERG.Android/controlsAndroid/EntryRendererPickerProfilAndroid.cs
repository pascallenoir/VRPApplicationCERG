using System;
using Android.Content;
using Android.Graphics.Drawables;
using VRPApplicationCERG.Controls;
using VRPApplicationCERG.Droid.controlsAndroid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryRendererPickerProfil), typeof(EntryRendererPickerProfilAndroid))]
namespace VRPApplicationCERG.Droid.controlsAndroid
{
    public class EntryRendererPickerProfilAndroid : PickerRenderer
    {

        public EntryRendererPickerProfilAndroid(Context context) : base(context)
        {
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {

                base.OnElementChanged(e);
                if (Control != null)
                {
                    Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
                }
            }
        }
    }

}