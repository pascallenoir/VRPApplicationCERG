using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using AndroidX.Core.View;
using VRPApplicationCERG.Controls;
using VRPApplicationCERG.Droid.controlsAndroid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MaterialFrame), typeof(MaterialFrameRenderer))]
namespace VRPApplicationCERG.Droid.controlsAndroid
{
   
    public class MaterialFrameRenderer : Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer
        {


        public MaterialFrameRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
            {
                base.OnElementChanged(e);
                if (e.NewElement == null)
                    return;

                UpdateElevation();
            }


            private void UpdateElevation()
            {
                var materialFrame = (MaterialFrame)Element;

                // we need to reset the StateListAnimator to override the setting of Elevation on touch down and release.
                Control.StateListAnimator = new Android.Animation.StateListAnimator();

                // set the elevation manually
                ViewCompat.SetElevation(this, materialFrame.Elevation);
                ViewCompat.SetElevation(Control, materialFrame.Elevation);
            }

            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);
                if (e.PropertyName == "Elevation")
                {
                    UpdateElevation();
                }
            }
        }
}