using System;
using CoreGraphics;
using UIKit;
using VRPApplicationCERG.iOS.controlsIos;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Picker), typeof(EntryRendererPickerMenuIos))]
namespace VRPApplicationCERG.iOS.controlsIos
{
    public class EntryRendererPickerMenuIos : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
                return;
            Control.BorderStyle = UITextBorderStyle.Line;
            Control.Layer.BorderWidth = 1;
            Control.Layer.BorderColor = Color.FromHex("#FFFFFF").ToCGColor();
            Control.Layer.BackgroundColor = Color.White.ToCGColor();

            Control.LeftView = new UIView(new CGRect(0, 0, 10, 0));
            Control.LeftViewMode = UITextFieldViewMode.Always;
        }
    }
}
