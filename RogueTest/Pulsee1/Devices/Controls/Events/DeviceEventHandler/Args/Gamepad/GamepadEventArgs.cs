using System;
using Pulsee1.Devices.Controls.Binding;

namespace Pulsee1.Devices.Controls.Events.DeviceEventHandler.Args.Gamepad
{
    class GamepadEventArgs : EventArgs
    {
        public GamepadButton Button { get; internal set; }

        public GamepadEventArgs() { return; }

        public GamepadEventArgs(GamepadEventArgs args)
        {
            Button = args.Button;
        }
    }
}
