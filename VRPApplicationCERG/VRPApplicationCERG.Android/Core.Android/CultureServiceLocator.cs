using Android.Content.Res;
using VRPApplicationCERG.Core;

namespace VRPApplicationCERG.Droid.Core.Android
{
    public class CultureServiceLocator : ICultureServiceLocator
    {
        public ICultureService Service => CultureService.Instance;

        [System.Obsolete]
        public static void NotifyLocaleChanged(Configuration newConfig)
        {
            CultureService.Instance.OnLocaleChanged(newConfig);
        }
    }
}
