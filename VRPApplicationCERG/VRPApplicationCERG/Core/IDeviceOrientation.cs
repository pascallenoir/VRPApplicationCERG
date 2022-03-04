using System;

namespace VRPApplicationCERG.Core
{
	public interface IDeviceOrientation
	{
		DeviceOrientation Orientation
		{
			get;
		}

		bool IsPortrait
		{
			get;
		}

		bool IsLandscape
		{
			get;
		}

		event EventHandler OrientationChanged;
	}
}
