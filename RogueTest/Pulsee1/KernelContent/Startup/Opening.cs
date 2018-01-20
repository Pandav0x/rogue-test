using System.Drawing;
using System.Drawing.Imaging;
using Pulsee1.Utilities.Display;
using Pulsee1.Display.Graphics.Textures;
using Pulsee1.Display.Graphics.Loader;

namespace Pulsee1.KernelContent.Startup
{
    static class Opening
    {
        private static GameManager _parent = null;
        private static  string _logoPath = @"Pulsee1\Pictures\Logos\poweredBy.png";

        public static void PrintLogoOnScreen(GameManager parent_)
        {
            if (_parent == null) //just in case y'know
                _parent = parent_;

            return;
        }
    }
}
