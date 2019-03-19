using System;
using System.Collections.Generic;
using Pulsee1.Devices.Controls.Binding;
using Pulsee1.Devices.Controls.Peripherals;

namespace Pulsee1.Devices.Controls.Events.DeviceEventHandler.Args.Gamepad
{
    class GamepadEventArgs : EventArgs
    {
        public GamepadButton Button { get; internal set; }

        public List<GamepadButton> Buttons { get; set; }

        public GamepadEventArgs() { return; }

        public GamepadEventArgs(GamepadEventArgs args)
        {
            this.Button = args.Button;
        }
    }
}
