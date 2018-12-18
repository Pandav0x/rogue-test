using Pulsee1.Graphics;
using Pulsee1.Utils.Display;
using System;

namespace Pulsee1.KernelContent.Startup
{
    static class Opening
    {
        private static GameManager _parent = null;
        private static string _splashPath = @"Pulsee1\KernelContent\Pictures\Splash\splashscreen.png";
        private static int? Alpha_currentStep = null;
        private static int? Alpha_totalStep = null;

        public static void PrintLogoOnScreen(GameManager parent_)
        {
            xConsole.WriteLine("Opening.PrintLogoOnScreen()", ConsoleColor.Red);

            if (Alpha_currentStep == null || Alpha_totalStep == null)
            {
                Alpha_currentStep = 0;
                Alpha_totalStep = 100;
            }

            if (_parent ==  null) //just in case y'know
                _parent = parent_;

            PulseGL.LoadSingle(_splashPath);


            return;
        }
    }
}
