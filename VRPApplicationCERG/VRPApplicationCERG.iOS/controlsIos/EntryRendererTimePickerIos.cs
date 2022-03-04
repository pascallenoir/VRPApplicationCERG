using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using VRPApplicationCERG.iOS.controlsIos;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TimePicker), typeof(EntryRendererTimePickerIos))]
namespace VRPApplicationCERG.iOS.controlsIos
{
    public class EntryRendererTimePickerIos : TimePickerRenderer
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