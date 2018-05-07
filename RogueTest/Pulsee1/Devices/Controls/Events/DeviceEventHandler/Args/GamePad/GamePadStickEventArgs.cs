using System;
using OpenTK.Input;

namespace Pulsee1.Devices.Controls.Events.DeviceEventHandler.Args.GamePad
{
    class GamePadStickEventArgs : EventArgs
    {
        public GamePadThumbSticks Stick { get; internal set; }

        public GamePadStickEventArgs() { return; }

        public GamePadStickEventArgs(GamePadStickEventArgs args)
        {
            Stick = args.Stick;
        }
    }
}
