using VRPApplicationCERG.Core;

namespace VRPApplicationCERG.iOS.Core.Ios
{
	public class CultureServiceLocator : ICultureServiceLocator
	{
		public ICultureService Service => CultureService.Instance;
	}
}
