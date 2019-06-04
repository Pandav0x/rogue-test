using System;
using Pulsee.Controls.Devices.Buttons;

namespace Pulsee.Controls.Gamepad
{
    class GamepadEventArgs : EventArgs
    {
        public GamepadButton Button { get; internal set; }

        public GamepadEventArgs() { return; }

        public GamepadEventArgs(GamepadEventArgs args)
        {
            this.Button = args.Button;
        }
    }
}
