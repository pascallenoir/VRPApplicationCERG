using System;

namespace VRPApplicationCERG.Core
{
	[AttributeUsage(AttributeTargets.Assembly)]
	public class GrialVersion : Attribute
	{
		public string Version
		{
			get;
		}

		public GrialVersion(string version)
		{
			Version = version;
		}
	}
}
