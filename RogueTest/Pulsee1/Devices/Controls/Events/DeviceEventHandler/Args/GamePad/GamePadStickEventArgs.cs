using System;
using OpenTK.Input;

namespace Pulsee1.Devices.Controls.Events.DeviceEventHandler.Args.Gamepad
{
    class GamepadStickEventArgs : EventArgs
    {
        public GamePadThumbSticks Stick { get; internal set; }

        public GamepadStickEventArgs() { return; }

        public GamepadStickEventArgs(GamepadStickEventArgs args)
        {
            Stick = args.Stick;
        }
    }
}
