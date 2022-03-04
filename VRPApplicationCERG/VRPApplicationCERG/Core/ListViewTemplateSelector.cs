using Xamarin.Forms;

namespace VRPApplicationCERG.Core
{
	public class ListViewTemplateSelector : TemplateSelector
	{
		protected override DataTemplate BuildDefault()
		{
			return new DataTemplate(() => new ViewCell
			{
				View = new Label
				{
					Text = "No matching template."
				}
			});
		}
	}
}
