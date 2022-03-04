using System;
using System.Threading.Tasks;

namespace VRPApplicationCERG.Core
{
	public class ForgottenExceptionEventArgs : EventArgs
	{
		public Task FaultedTask
		{
			get;
		}

		public ForgottenExceptionEventArgs(Task task)
		{
			FaultedTask = task;
		}
	}
}
