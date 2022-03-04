using System;
using System.Globalization;

namespace VRPApplicationCERG.Core
{
	public interface ILayoutDirectionService
	{
		LayoutDirection LayoutDirection
		{
			get;
		}

		LayoutDirection DeviceNativeDirection
		{
			get;
		}

		event EventHandler LayoutDirectionChanged;

		void SimulateLayoutDirectionChange(LayoutDirection direction);

		LayoutDirection ReadCultureLayoutDirection(CultureInfo ci);
	}
}
