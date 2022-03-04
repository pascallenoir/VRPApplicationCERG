using System;
using Android.Content;
using VRPApplicationCERG.Controls;
using VRPApplicationCERG.Droid.controlsAndroid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryRendererDatePicker), typeof(EntryRendererDatePickerAndroid))]
namespace VRPApplicationCERG.Droid.controlsAndroid
{
    
    public class EntryRendererDatePickerAndroid : DatePickerRenderer
	{

        public EntryRendererDatePickerAndroid(Context context) : base(context)
        {

        }

        public static void Init() { }
		protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
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