using System;
using Pulsee1.Devices.Controls.Binding;

namespace Pulsee1.Devices.Controls.Events.DeviceEventHandler.Args.GamePad
{
    class GamePadButtonEventArgs : EventArgs
    {
        public GamePadButton Button { get; internal set; }

        public GamePadButtonEventArgs() { return; }

        public GamePadButtonEventArgs(GamePadButtonEventArgs args)
        {
            Button = args.Button;
        }

    }
}
