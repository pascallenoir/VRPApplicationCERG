using Android.Content;
using Android.Views;
using VRPApplicationCERG.Core;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

namespace VRPApplicationCERG.Droid.Core.Android
{
    public class TextCellRenderer : Xamarin.Forms.Platform.Android.TextCellRenderer
    {
        protected override View GetCellCore(Cell item, View convertView, ViewGroup parent, Context context)
        {
            View cellCore = base.GetCellCore(item, convertView, parent, context);
            SetColors(cellCore);
            return cellCore;
        }

        public static void SetColors(View view)
        {
            (view as BaseCellView)?.SetDefaultMainTextColor(ColorCache.ListViewItemTextColor);
        }
    }
}
