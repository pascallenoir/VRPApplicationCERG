using System;
using System.ComponentModel;
using CoreGraphics;
using UIKit;
using VRPApplicationCERG.iOS.controlsIos;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(DatePicker), typeof(EntryRendererDatePickerIos))]
namespace VRPApplicationCERG.iOS.controlsIos
{
    public class EntryRendererDatePickerIos : DatePickerRenderer
    {
        public new static void Init() { }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control != null)
            {

                Control.Layer.BorderWidth = 0;
                Control.BorderStyle = UITextBorderStyle.None;

            }

        }
    }
}