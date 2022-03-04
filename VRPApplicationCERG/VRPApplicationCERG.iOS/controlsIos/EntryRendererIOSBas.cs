using System;
using CoreGraphics;
using VRPApplicationCERG.Controls;
using VRPApplicationCERG.iOS.controlsIos;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EntryRendererIdentiteBas), typeof(EntryRendererIOSBas))]
namespace VRPApplicationCERG.iOS.controlsIos
{
    public class EntryRendererIOSBas : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.Layer.MaskedCorners = (CoreAnimation.CACornerMask)12;
                Control.Layer.CornerRadius = 3f;
                Control.Layer.BorderWidth = 0f;
                Control.Layer.BorderColor = Color.White.ToCGColor();
                Control.Layer.BackgroundColor = Color.White.ToCGColor();

                Control.LeftView = new UIKit.UIView(new CGRect(0, 0, 10, 0));
                Control.LeftViewMode = UIKit.UITextFieldViewMode.Always;
            }
        }
    }
}
