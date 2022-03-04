using System;
using Android.Content;
using Android.Graphics.Drawables;
using VRPApplicationCERG.Controls;
using VRPApplicationCERG.Droid.controlsAndroid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(EntryRenderers), typeof(EntryRenderersAndroid))]
namespace VRPApplicationCERG.Droid.controlsAndroid
{
   
    public class EntryRenderersAndroid : EntryRenderer
    {
        public EntryRenderersAndroid(Context context) : base(context)
        {
            AutoPackage = false;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }

}
