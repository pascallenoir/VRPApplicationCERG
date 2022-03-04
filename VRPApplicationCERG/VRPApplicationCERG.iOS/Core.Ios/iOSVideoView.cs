using AVFoundation;
using AVKit;

namespace VRPApplicationCERG.iOS.Core.Ios
{
	internal class iOSVideoView
	{
		public AVPlayer Player
		{
			get;
			set;
		}

		public AVPlayerItem PlayerItem
		{
			get;
			set;
		}

		public AVPlayerViewController PlayerViewController
		{
			get;
			set;
		}
	}
}
