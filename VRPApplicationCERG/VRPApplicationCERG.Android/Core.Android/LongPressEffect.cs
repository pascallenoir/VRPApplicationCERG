using Android.Runtime;
using Android.Views;
using Java.Lang;
using System;
using System.Windows.Input;
using VRPApplicationCERG.Core;
using VRPApplicationCERG.Droid.Core.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

namespace VRPApplicationCERG.Droid.Core.Android
{
    internal class LongPressEffect : PlatformEffect
    {
        private class OnLongLickListener : Java.Lang.Object, View.IOnLongClickListener, IJavaObject, IDisposable
        {
            private Element element;

            public OnLongLickListener(Element element)
            {
                this.element = element;
            }

            public bool OnLongClick(View v)
            {
                ICommand longPressCommand = Events.GetLongPressCommand(element);
                if (longPressCommand != null)
                {
                    object longPressCommandParameter = Events.GetLongPressCommandParameter(element);
                    if (longPressCommand.CanExecute(longPressCommandParameter))
                    {
                        longPressCommand.Execute(longPressCommandParameter);
                        return true;
                    }
                }
                return false;
            }
        }

        private View view;

        private bool isAttached;

        protected override void OnAttached()
        {
            view = ((base.Control == null) ? base.Container : base.Control);
            if (view != null)
            {
                isAttached = true;
                view.SetOnLongClickListener(new OnLongLickListener(base.Element));
            }
        }

        protected override void OnDetached()
        {
            if (isAttached)
            {
                try
                {
                    isAttached = false;
                    view.SetOnKeyListener(null);
                }
                catch
                {
                }
            }
        }
    }
}
