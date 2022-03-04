using Xamarin.Forms;

namespace VRPApplicationCERG.Core
{
	[ContentProperty("DataTemplate")]
	public class IntMemberTemplateSelectorItem
	{
		public DataTemplate DataTemplate
		{
			get;
			set;
		}

		public int Value
		{
			get;
			set;
		}
	}
}
