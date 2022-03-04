using System;
using CoreGraphics;
using VRPApplicationCERG.Controls;
using VRPApplicationCERG.iOS.controlsIos;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EntryRendererProfil), typeof(EntryRendererProfilIOS))]
namespace VRPApplicationCERG.iOS.controlsIos
{
    public class EntryRendererProfilIOS : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
                return;

            Control.Layer.CornerRadius = 4;
            Control.Layer.BorderWidth = 1;
            Control.Layer.BorderColor = Color.FromHex("#e7eaf3").ToCGColor();
            Control.Layer.BackgroundColor = Color.FromHex("#FFFFFF").ToCGColor();
            

            Control.LeftView = new UIKit.UIView(new CGRect(0, 0, 10, 0));
            Control.LeftViewMode = UIKit.UITextFieldViewMode.Always;
        }
    }
}
