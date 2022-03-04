using Android.Content.Res;
using VRPApplicationCERG.Core;

namespace VRPApplicationCERG.Droid.Core.Android
{
    public class LayoutDirectionServiceLocator : ILayoutDirectionServiceLocator
    {
        public ILayoutDirectionService Service => LayoutDirectionService.Instance;

        public static void NotifyLayoutDirectionChanged(Configuration newConfig)
        {
            LayoutDirectionService.Instance.OnNotifyLayoutDirectionChanged(newConfig);
        }
    }
}
