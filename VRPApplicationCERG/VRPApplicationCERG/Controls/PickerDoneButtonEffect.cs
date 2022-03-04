using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace VRPApplicationCERG.Controls
{
    public static class PickerDoneButtonEffect
    {
        public static BindableProperty DoneButtonTextProperty =
           BindableProperty.CreateAttached("DoneButtonText",
                                           typeof(string),
                                           typeof(PickerDoneButtonEffect),
                                           string.Empty,
                                           propertyChanged: OnDoneButtonPropertyPropertyChanged);

        public static string GetDoneButtonText(BindableObject element)
        {
            return (string)element.GetValue(DoneButtonTextProperty);
        }

        public static void SetTintColor(BindableObject element, string value)
        {
            element.SetValue(DoneButtonTextProperty, value);
        }

        static void OnDoneButtonPropertyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            AttachEffect(bindable as Xamarin.Forms.View, $"{newValue}");
        }

        static void AttachEffect(Xamarin.Forms.View element, string buttonText)
        {
            var effect = element.Effects.FirstOrDefault(x => x is PickerDoneButton) as PickerDoneButton;

            if (effect != null)
            {
                element.Effects.Remove(effect);
            }

            element.Effects.Add(new PickerDoneButton(buttonText));
        }

        public class PickerDoneButton : RoutingEffect
        {
            public string ButtonTitle { get; set; }

            public PickerDoneButton(string buttonTitle) : base($"SaveAll.{nameof(PickerDoneButton)}")
            {
                ButtonTitle = buttonTitle;
            }
        }
    }
}
