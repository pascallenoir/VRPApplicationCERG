using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using System.ComponentModel;
using VRPApplicationCERG.Core;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

namespace VRPApplicationCERG.Droid.Core.Android
{
    public class SliderRenderer : Xamarin.Forms.Platform.Android.SliderRenderer
    {
        public SliderRenderer(Context context)
            : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);
            if (base.Control == null)
            {
                return;
            }
            Xamarin.Forms.Color sliderColor = GetSliderColor(e.NewElement);
            if (sliderColor != Xamarin.Forms.Color.Default)
            {
                if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop)
                {
                    SetColorFilter(e.NewElement.IsEnabled ? sliderColor : ColorCache.GetDisabledColorFor(sliderColor));
                    return;
                }
                Color color = sliderColor.ToAndroid();
                Color disabled = sliderColor.AddLuminosity((0.0 - sliderColor.Luminosity) / 2.0).ToAndroid();
                base.Control.ProgressBackgroundTintList = Utils.CreateColorStateList(Color.Gray);
                base.Control.ProgressBackgroundTintMode = PorterDuff.Mode.SrcAtop;
                ColorStateList colorStateList = Utils.CreateColorStateList(color, disabled, color);
                base.Control.ProgressTintList = colorStateList;
                base.Control.ProgressTintMode = PorterDuff.Mode.SrcAtop;
                base.Control.ThumbTintList = colorStateList;
                base.Control.ThumbTintMode = PorterDuff.Mode.SrcAtop;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop && e.PropertyName == "IsEnabled")
            {
                Xamarin.Forms.Color sliderColor = GetSliderColor(base.Element);
                if (sliderColor != Xamarin.Forms.Color.Default)
                {
                    SetColorFilter(base.Element.IsEnabled ? sliderColor : ColorCache.GetDisabledColorFor(sliderColor));
                }
            }
        }

        private void SetColorFilter(Xamarin.Forms.Color tintColor)
        {
            if (base.Control.ProgressDrawable != null)
            {
                base.Control.ProgressDrawable.SetColorFilter(new PorterDuffColorFilter(tintColor.ToAndroid(), PorterDuff.Mode.SrcAtop));
            }
            if (base.Control.Thumb != null)
            {
                base.Control.Thumb.SetColorFilter(new PorterDuffColorFilter(tintColor.ToAndroid(), PorterDuff.Mode.SrcAtop));
            }
        }

        private Xamarin.Forms.Color GetSliderColor(Slider slider)
        {
            Xamarin.Forms.Color color = SliderProperties.GetTintColor(slider);
            if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop && color == Xamarin.Forms.Color.Default)
            {
                color = ColorCache.AccentColor;
            }
            return color;
        }
    }
}
