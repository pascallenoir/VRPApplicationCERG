using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using VRPApplicationCERG.Controls;
using VRPApplicationCERG.Droid.controlsAndroid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using TimePicker = Xamarin.Forms.TimePicker;

[assembly: ExportRenderer(typeof(EntryRendererTimePicker), typeof(EntryRendererTimePickerAndroid))]
namespace VRPApplicationCERG.Droid.controlsAndroid
{
    public class EntryRendererTimePickerAndroid : TimePickerRenderer
	{

		public EntryRendererTimePickerAndroid(Context context) : base(context)
		{

		}

		public static void Init() { }
		protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement == null)
			{

				Control.SetBackgroundResource(Resource.Layout.rounded_shape);
				var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
				layoutParams.SetMargins(0, 0, 0, 0);
				LayoutParameters = layoutParams;
				Control.LayoutParameters = layoutParams;
				Control.SetPadding(0, 0, 0, 0);
				SetPadding(0, 0, 0, 0);
			}
		}
	}
}