using System;

namespace VRPApplicationCERG.Core
{
	public class TabTappedEventArgs : EventArgs
	{
		public object Tab
		{
			get;
		}

		public TabTappedEventArgs(object tab)
		{
			Tab = tab;
		}
	}
}
