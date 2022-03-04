using VRPApplicationCERG.Core;

namespace VRPApplicationCERG.iOS.Core.Ios
{
	internal class DeviceOrientationLocator : IDeviceOrientationServiceLocator
	{
		public IDeviceOrientation Service => DeviceOrientationImpl.Instance;
	}
}
