using OpenTK.Input;

namespace Pulsee1.Devices.Controls.Peripherals
{
    class Ple_Keyboard
    {
        private static Ple_Keyboard _instance;

        private Ple_Keyboard()
        {
            return;
        }

        public static Ple_Keyboard GetInstance()
        {
            if (Ple_Keyboard._instance == null)
                Ple_Keyboard._instance = new Ple_Keyboard();
            return Ple_Keyboard._instance;
        }
    }
}
