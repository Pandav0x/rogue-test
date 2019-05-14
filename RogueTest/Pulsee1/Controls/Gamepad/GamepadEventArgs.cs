using System;
using Pulsee1.Controls.Devices.Buttons;

namespace Pulsee1.Controls.Gamepad
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
