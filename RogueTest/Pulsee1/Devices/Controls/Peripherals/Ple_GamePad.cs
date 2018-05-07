using System;
using OpenTK.Input;
using Pulsee1.Utils.Display;

namespace Pulsee1.Devices.Controls.Peripherals
{
    class Ple_GamePad
    {
        private static Ple_GamePad _instance;

        private Ple_GamePad()
        {
            return;
        }

        public static Ple_GamePad GetInstance()
        {
            if (Ple_GamePad._instance == null)
                Ple_GamePad._instance = new Ple_GamePad();
            return Ple_GamePad._instance;
        }


        #region TODEL
        public static void tmp_Main()
        {
            xConsole.WriteLine(new String('-', 40), System.ConsoleColor.Green);

            for(int i = 0;; i++)
            {
                if (!GamePad.GetState(i).IsConnected)
                    break;
                xConsole.WriteLine(i + ": " + GamePad.GetName(i), System.ConsoleColor.Green);
                xConsole.WriteLine("\tIs plugged: " + GamePad.GetState(i).IsConnected.ToString(), System.ConsoleColor.Green);

                GamePadCapabilities kappa = GamePad.GetCapabilities(i);

                xConsole.WriteLine("\t" + kappa.GamePadType.ToString(), System.ConsoleColor.Green);
 
            }

            xConsole.WriteLine(new String('-', 40), System.ConsoleColor.Green);
            return;
        }
        #endregion

    }
}
