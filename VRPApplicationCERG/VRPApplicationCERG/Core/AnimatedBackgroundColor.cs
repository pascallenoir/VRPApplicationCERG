using Xamarin.Forms;

namespace VRPApplicationCERG.Core
{
	public class AnimatedBackgroundColor : AnimatedColor
	{
		protected override void SetPropertyValue(Color value)
		{
			base.Target.BackgroundColor = value;
		}
	}
}
