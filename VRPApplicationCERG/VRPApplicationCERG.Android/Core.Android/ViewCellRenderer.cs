using Android.Content;
using Android.Views;
using Xamarin.Forms;
using View = Android.Views.View;

namespace VRPApplicationCERG.Droid.Core.Android
{
    public class ViewCellRenderer : Xamarin.Forms.Platform.Android.ViewCellRenderer
    {
        protected override View GetCellCore(Cell item, View convertView, ViewGroup parent, Context context)
        {
            View cellCore = base.GetCellCore(item, convertView, parent, context);
            TextCellRenderer.SetColors(cellCore);
            return cellCore;
        }
    }
}
