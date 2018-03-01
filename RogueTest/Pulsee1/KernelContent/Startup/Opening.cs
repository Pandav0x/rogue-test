using Pulsee1.Graphics;
using Pulsee1.Graphics.Loader;

namespace Pulsee1.KernelContent.Startup
{
    static class Opening
    {
        private static GameManager _parent = null;
        private static string _splashPath = @"Pulsee1\KernelContent\Pictures\Splash\splashscreen.png";

        public static void PrintLogoOnScreen(GameManager parent_)
        {
            if (_parent == null) //just in case y'know
                _parent = parent_;

            //PulseGL.GLDrawScene(_splashPath);
            PulseGL.LoadTemp(_splashPath);

            return;
        }
    }
}
