using System;

namespace VRPApplicationCERG.Core
{
	public class GrialException : Exception
	{
		public GrialException(string message)
			: base(message)
		{
		}

		public GrialException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
