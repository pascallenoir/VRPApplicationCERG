using Xamarin.Forms;

namespace VRPApplicationCERG.Core
{
	public interface IMirrorService
	{
		void Mirror(VisualElement target, LayoutDirection direction);
	}
}
