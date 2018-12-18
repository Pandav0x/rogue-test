using System;
using Pulsee1.Devices.Controls.Binding;

namespace Pulsee1.Devices.Controls.Events.DeviceEventHandler.Args.Gamepad
{
    class GamepadButtonEventArgs : EventArgs
    {
        public GamepadButton Button { get; internal set; }

        public GamepadButtonEventArgs() { return; }

        public GamepadButtonEventArgs(GamepadButtonEventArgs args)
        {
            Button = args.Button;
        }

    }
}
