using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using System.Reflection;
using VRPApplicationCERG.Core;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

namespace VRPApplicationCERG.Droid.Core.Android
{
    public class EntryCellRenderer : Xamarin.Forms.Platform.Android.EntryCellRenderer, IDisposable
    {
        private bool disposed;

        private static bool _propertyNotAvailable;

        private static PropertyInfo _editTextProperty;

        private WeakReference<EditText> _editView;

        protected override View GetCellCore(Cell item, View convertView, ViewGroup parent, Context context)
        {
            View cellCore = base.GetCellCore(item, convertView, parent, context);
            if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop && TryGetEditText(cellCore, out EditText edit))
            {
                _editView = new WeakReference<EditText>(edit);
                edit.FocusChange += FocusChanged;
            }
            return cellCore;
        }

        [Obsolete]
        private void FocusChanged(object sender, View.FocusChangeEventArgs e)
        {
            EditText editText = sender as EditText;
            if (editText != null && editText.Background != null)
            {
                if (e.HasFocus)
                {
                    editText.Background.SetColorFilter(ColorCache.AccentColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
                }
                else
                {
                    editText.Background.ClearColorFilter();
                }
            }
        }

        private static bool TryGetEditText(View cell, out EditText edit)
        {
            edit = null;
            if (_propertyNotAvailable)
            {
                return false;
            }
            if (_editTextProperty == null)
            {
                _editTextProperty = cell.GetType().GetProperty("EditText");
                if (_editTextProperty == null)
                {
                    _propertyNotAvailable = true;
                    return false;
                }
            }
            edit = (_editTextProperty.GetValue(cell) as EditText);
            return edit != null;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing && !disposed)
            {
                disposed = true;
                if (_editView != null && _editView.TryGetTarget(out EditText target))
                {
                    target.FocusChange -= FocusChanged;
                }
            }
        }
    }
}
