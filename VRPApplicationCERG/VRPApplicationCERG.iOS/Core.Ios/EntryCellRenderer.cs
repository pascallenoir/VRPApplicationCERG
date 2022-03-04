using UIKit;
using Xamarin.Forms;

namespace VRPApplicationCERG.iOS.Core.Ios
{
    public class EntryCellRenderer : Xamarin.Forms.Platform.iOS.EntryCellRenderer
	{
		public EntryCellRenderer()
		{
		}

		public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			UITableViewCell cell = base.GetCell(item, reusableCell, tv);
			ViewCellRenderer.UpdateCell(item, cell);
			return cell;
		}
	}
}
