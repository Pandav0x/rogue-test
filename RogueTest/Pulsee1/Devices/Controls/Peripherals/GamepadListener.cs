using System;
using System.Collections.Generic;
using OpenTK.Input;
using Pulsee1.Utils.Display;
using RogueTest.Pulsee1.Devices.Display.Window;

namespace Pulsee1.Devices.Controls.Peripherals
{
    class GamepadListener
    {
        private static System.Threading.Thread _gamepadListener;
        private static GamepadListener _instance = null;

        private static List<GamepadDevice> _gamepadDevices;

        public GamepadListener() { return; }

        public static void GetGamepadDevices()
        {
            int index = 0;
            do
            {
                //TODO : handle if no gamepad is connected (currently shows 1 controller)
                xConsole.WriteLine(GamePad.GetName(index));
                _gamepadDevices.Add(new GamepadDevice(index));

            } while (GamePad.GetName(++index) != ""); //While the name is not nothing => while there's smthg

            xConsole.WriteLine("Total GamePad devices detected: " + _gamepadDevices.Count, ConsoleColor.Cyan);

            return;
        }

        public static void Start(Ple_GameWindow context)
        {
            _instance = _instance ?? new GamepadListener();
            _gamepadDevices = new List<GamepadDevice>();

            GetGamepadDevices();

            foreach (GamepadDevice gd in _gamepadDevices)
            {
                gd.StartListening(context);
            }

            return;
        }
    }
}
