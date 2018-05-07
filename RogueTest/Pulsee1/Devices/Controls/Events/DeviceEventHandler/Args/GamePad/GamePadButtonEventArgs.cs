using System;
using OpenTK.Input;

namespace Pulsee1.Devices.Controls.Events.DeviceEventHandler.Args.GamePad
{
    class GamePadButtonEventArgs : EventArgs
    {
        public GamePadButtons Button { get; internal set; }

        public GamePadButtonEventArgs() { return; }

        public GamePadButtonEventArgs(GamePadButtonEventArgs args)
        {
            Button = args.Button;
        }

    }
}
