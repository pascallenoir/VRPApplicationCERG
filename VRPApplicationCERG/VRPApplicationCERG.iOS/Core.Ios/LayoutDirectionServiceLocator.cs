using VRPApplicationCERG.Core;

namespace VRPApplicationCERG.iOS.Core.Ios
{
	public class LayoutDirectionServiceLocator : ILayoutDirectionServiceLocator
	{
		public ILayoutDirectionService Service => LayoutDirectionService.Instance;
	}
}
