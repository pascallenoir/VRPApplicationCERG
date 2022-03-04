using System;

namespace VRPApplicationCERG.Core
{
	public class IsCheckedChangedEventArgs : EventArgs
	{
		public bool IsChecked
		{
			get;
			set;
		}
	}
}
