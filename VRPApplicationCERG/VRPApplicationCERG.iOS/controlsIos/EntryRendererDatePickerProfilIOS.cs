using System;
using System.ComponentModel;
using CoreGraphics;
using UIKit;
using VRPApplicationCERG.Controls;
using VRPApplicationCERG.iOS.controlsIos;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EntryRendererDatePickerProfil), typeof(EntryRendererDatePickerProfilIOS))]
namespace VRPApplicationCERG.iOS.controlsIos
{
    public class EntryRendererDatePickerProfilIOS : DatePickerRenderer
    {
        public new static void Init() { }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender,e);


           
        }
    }
}