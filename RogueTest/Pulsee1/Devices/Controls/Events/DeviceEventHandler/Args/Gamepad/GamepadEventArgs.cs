using System;
using System.Collections.Generic;
using Pulsee1.Devices.Controls.Binding;
using Pulsee1.Devices.Controls.Peripherals;

namespace Pulsee1.Devices.Controls.Events.DeviceEventHandler.Args.Gamepad
{
    class GamepadEventArgs : EventArgs
    {
        //TODO : Add a reference to the previously pressed button in order to get it in the release event arg

        public GamepadButton Button { get; internal set; }

        public GamepadEventArgs() { return; }

        public GamepadEventArgs(GamepadEventArgs args)
        {
            this.Button = args.Button;
        }
    }
}
