using System;
using OpenTK.Input;

namespace Pulsee1.Devices.Controls.Events.DeviceEventHandler.Args.GamePad
{
    class GamePadTriggerEventArgs : EventArgs
    {
        public GamePadTriggers Trigger { get; internal set; }

        public GamePadTriggerEventArgs() { return; }

        public GamePadTriggerEventArgs(GamePadTriggerEventArgs args)
        {
            Trigger = args.Trigger;
        }
    }
}
