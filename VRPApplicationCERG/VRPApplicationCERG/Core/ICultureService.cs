using System.Globalization;

namespace VRPApplicationCERG.Core
{
	public interface ICultureService
	{
		CultureInfo CurrentCulture
		{
			get;
		}

		event CultureChangedEventHandler CurrentCultureChanged;

		void SimulateCultureChange(CultureInfo ci);
	}
}
