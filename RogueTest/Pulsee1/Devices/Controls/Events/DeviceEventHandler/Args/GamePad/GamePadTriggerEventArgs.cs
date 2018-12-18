using System;
using OpenTK.Input;

namespace Pulsee1.Devices.Controls.Events.DeviceEventHandler.Args.Gamepad
{
    class GamepadTriggerEventArgs : EventArgs
    {
        public GamePadTriggers Trigger { get; internal set; }

        public GamepadTriggerEventArgs() { return; }

        public GamepadTriggerEventArgs(GamepadTriggerEventArgs args)
        {
            Trigger = args.Trigger;
        }
    }
}
