using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using VRPApplicationCERG.Controls;
using VRPApplicationCERG.iOS.controlsIos;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SearchBarRendererControl), typeof(SearchBarRendererIOS))]
namespace VRPApplicationCERG.iOS.controlsIos
{
    public class SearchBarRendererIOS : SearchBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.Layer.BorderWidth = 0;
                Control.BackgroundColor = null;
                Control.SearchBarStyle = UISearchBarStyle.Default;
            }
        }
    }
}